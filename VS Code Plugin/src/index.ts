import * as path from "path"
import { window, ExtensionContext, languages, workspace, DiagnosticCollection, TextDocument, Diagnostic, DiagnosticSeverity, Position, Range, TextDocumentContentChangeEvent, SemanticTokens, SemanticTokensLegend, DocumentSemanticTokensProvider, EventEmitter, SemanticTokensBuilder, DocumentRangeSemanticTokensProvider, SemanticTokensEdits, TextDocumentChangeEvent, SemanticTokensEdit, Uri, CancellationToken, CancellationTokenSource, Disposable, HoverProvider, Hover, MarkdownString, commands, DocumentLinkProvider, DocumentLink, CodeAction, CodeActionProvider, WorkspaceEdit, FileDeleteEvent, ProcessExecution, FileRenameEvent, FileWillDeleteEvent, FileWillRenameEvent } from "vscode"
import {HubConnectionBuilder, HubConnectionState, LogLevel} from "@microsoft/signalr"

class SerialDisposable implements Disposable {
    f : () => any

    constructor(public callOnDispose: () => any) {
        this.f = callOnDispose
    }

    assign(callOnDispose: () => any) {
        this.f()
        this.f = callOnDispose;
    }
 
    dispose() {
        this.f(); 
        this.f = () => {}
    }
}

const port : number = workspace.getConfiguration("spiral").get("port") || 13805
const hubTimeout = 1000
const hub = new HubConnectionBuilder()
    .withUrl(`http://localhost:${port}`)
    .configureLogging(LogLevel.Error)
    .withAutomaticReconnect({
        nextRetryDelayInMilliseconds: x => hubTimeout
    })
    .build()

function sleep(ms : number) {
  return new Promise(resolve => setTimeout(resolve, ms));
}

async function hubStart() {
    while (true) {
        try {
            await hub.start();
            return
        } catch (err : any) {
            await sleep(hubTimeout)
        }
    }
    throw Error("Max connection attempts elapsed. Spiral VS Code Client has failed to connect to the Spiral server.")
}

const requestRun = async (prev : Promise<string | null>, file: any): Promise<string | null> => {
    await prev // Waiting on the previous request is so they get ordered properly. Otherwise, messages might fill up and fire in arbitrary order.
    const msg = JSON.stringify(file)
    const x = await hub.invoke("ClientToServerMsg",msg)
    return x ? x.toString() : null
}
let prev_request : Promise<string | null> = new Promise(resolve => resolve(null))
const request = async (file: any) => { prev_request = requestRun(prev_request,file); return prev_request }
const requestJSON = (file : any) => request(file).then(x => x ? JSON.parse(x) : undefined)

type VSCPos = { line: number, character: number }
type VSCRange = [VSCPos, VSCPos]
type RString = [VSCRange, string]

type ProjectCodeAction = 
    | { CreateFile: {filePath : string} }
    | { DeleteFile: {range: VSCRange; filePath : string} }
    | { RenameFile: {filePath : string; target : string} }
    | { CreateDirectory: {dirPath : string} }
    | { DeleteDirectory: {range: VSCRange; dirPath : string} } // The range here is for the whole tree, not just the code action activation.
    | { RenameDirectory: {dirPath : string; target : string; validate_as_file : boolean} }

type RAction = [VSCRange, ProjectCodeAction]

const spiprojOpenReq = async (uri: string, spiprojText: string): Promise<void> => requestJSON({ ProjectFileOpen: { uri, spiprojText } })
const spiprojChangeReq = async (uri: string, spiprojText: string): Promise<void> => requestJSON({ ProjectFileChange: { uri, spiprojText } })
const spiprojLinksReq = async (uri: string): Promise<RString []> => requestJSON({ ProjectFileLinks: { uri } })
const spiprojCodeActionsReq = async (uri: string): Promise<RAction []> => requestJSON({ ProjectCodeActions: { uri } })
const spiprojCodeActionExecuteReq = async (uri: string, action : ProjectCodeAction): Promise<string | null> => requestJSON({ ProjectCodeActionExecute: { uri, action } }).then(x => x.result)

const spiOpenReq = async (uri: string, spiText: string): Promise<void> => requestJSON({ FileOpen: { uri, spiText } })
const spiChangeReq = async (uri: string, spiEdit : {from: number, nearTo: number, lines: string[]} ): Promise<void> => 
    requestJSON({ FileChange: { uri, spiEdit } })
const spiDeleteReq = async (uris: string []): Promise<void> => requestJSON({ FileDelete: { uris } })
const spiTokenRangeReq = async (uri: string, range : Range): Promise<number []> => requestJSON({ FileTokenRange: { uri, range } })
const spiHoverAtReq = async (uri: string, pos : Position): Promise<string | null> => request({ HoverAt: { uri, pos } })
const spiBuildFileReq = async (uri: string, backend : string): Promise<void> => requestJSON({ BuildFile: {uri, backend} })

const range = (x : VSCRange) => new Range(x[0].line, x[0].character, x[1].line, x[1].character)

const errorsSet = (errors : DiagnosticCollection, uri: Uri, x: RString[]) => {
    errors.set(uri, x.map(([r, er]) => new Diagnostic(range(r), er, DiagnosticSeverity.Error)))
}

type Errors = {uri : string; errors : RString[]}
type ClientRes = 
    | { FatalError: string }
    | { TracedError: {trace : string [], message :string}}
    | { PackageErrors: Errors } | { TokenizerErrors: Errors } 
    | { ParserErrors: Errors } | { TypeErrors: Errors }

const projectCodeActionTitle = (x : ProjectCodeAction): string => {
    if ("CreateFile" in x) {return "Create file."}
    if ("DeleteFile" in x) {return "Delete file."}
    if ("RenameFile" in x) {return "Rename file."}
    if ("CreateDirectory" in x) {return "Create directory."}
    if ("DeleteDirectory" in x) {return "Delete directory."}
    if ("RenameDirectory" in x) {return "Rename directory."}
    throw "Case match failed"
    }

export const activate = async (ctx: ExtensionContext) => {
    const errorsProject = languages.createDiagnosticCollection()
    const errorsTokenization = languages.createDiagnosticCollection()
    const errorsParse = languages.createDiagnosticCollection()
    const errorsType = languages.createDiagnosticCollection()

    const spiprojOpen = (doc: TextDocument) => spiprojOpenReq(doc.uri.toString(true), doc.getText())
    const spiprojChange = (doc: TextDocument) => spiprojChangeReq(doc.uri.toString(true), doc.getText())
    const spiOpen = (doc: TextDocument) => spiOpenReq(doc.uri.toString(true), doc.getText())

    const numberOfLinesAdded = (str: string) => {
        var length = 0;
        for (var i = 0; i < str.length; i++) { if (str[i] == '\n') { length++; } }
        return length;
    }

    const spiChange = async (doc : TextDocument, changes: readonly TextDocumentContentChangeEvent[]) => {
        if (0 < changes.length) {
            const sortedChanges = 1 < changes.length ? [...changes].sort((a,b) => a.range.start.compareTo(b.range.start)) : changes
            const from = sortedChanges[0].range.start.line
            const {nearTo} =
                sortedChanges.reduce(({lineAdjust},x) => {
                    const linesRemoved = x.range.end.line - x.range.start.line
                    const linesAdded = numberOfLinesAdded(x.text)
                    return {
                        nearTo: lineAdjust + linesAdded + x.range.start.line + 1, 
                        lineAdjust: lineAdjust + linesAdded - linesRemoved
                        }
                    }, {nearTo: 0, lineAdjust: 0})
            const lines : string [] = []
            for (let i = from; i < nearTo; i++) { lines.push(doc.lineAt(i).text) }
            const edit = {lines, from, nearTo: sortedChanges[sortedChanges.length-1].range.end.line+1}
            spiChangeReq(doc.uri.toString(true), edit)
        }
    }
    const spiDelete = (uri: readonly Uri []) => spiDeleteReq(uri.map(x => x.toString(true)))

    class SpiralTokens implements DocumentRangeSemanticTokensProvider {
        async provideDocumentRangeSemanticTokens(doc: TextDocument, range : Range) {
            const x = await spiTokenRangeReq(doc.uri.toString(true), range)
            return new SemanticTokens(new Uint32Array(x),"")
        }
    }

    class SpiralHover implements HoverProvider {
        async provideHover(document: TextDocument, position: Position) {
            const x = await spiHoverAtReq(document.uri.toString(true),position)
            if (x) {
                return new Hover(new MarkdownString().appendCodeblock(x,'plaintext'))
            }
        }
    }

    const onDocOpen = (doc: TextDocument) => {
        switch (path.extname(doc.uri.path)) {
            case ".spiproj": 
                if (path.basename(doc.uri.path,".spiproj") === "package") {spiprojOpen(doc)}
                return
            case ".spir": case ".spi": return spiOpen(doc)
            default: return
        }
    }
    const onDocChange = (x: TextDocumentChangeEvent) => {
        switch (path.extname(x.document.uri.path)) {
            case ".spiproj": 
                if (path.basename(x.document.uri.path,".spiproj") === "package") { spiprojChange(x.document) }
                return
            case ".spir": case ".spi": return spiChange(x.document,x.contentChanges)
            default: return
        }
    }

    const onDelete = (e: FileDeleteEvent) => spiDelete(e.files)
    const onRename = (e: FileRenameEvent) => spiDelete(e.files.map(x => x.oldUri))
    class SpiralProjectLinks implements DocumentLinkProvider {
        async provideDocumentLinks(document: TextDocument) {
            const x = await spiprojLinksReq(document.uri.toString(true))
            return x.map(x => new DocumentLink(range(x[0]),Uri.parse(x[1],true)))
        }
    }

    class SpiralProjectCodeActions implements CodeActionProvider {
        async provideCodeActions(doc : TextDocument, r : Range) {
            const uri = doc.uri.toString(true)
            const actions = await spiprojCodeActionsReq(uri)
            return actions.filter(x => range(x[0]).contains(r))
                .map(x => {
                    const a = new CodeAction(projectCodeActionTitle(x[1]))
                    a.command = {command: "runClosure", title: "Run closure", arguments:[async () => {
                        let error : string | null = null
                        if ("CreateFile" in x[1] || "CreateDirectory" in x[1]) {
                            error = await spiprojCodeActionExecuteReq(uri,x[1])
                        }
                        if ("RenameFile" in x[1] || "RenameDirectory" in x[1]) {
                            const r = range(x[0])
                            const target = await window.showInputBox({value: doc.getText(r), prompt: "Enter a new file name."})
                            if (target) {
                                if ("RenameDirectory" in x[1]) {x[1].RenameDirectory.target = target}
                                else {x[1].RenameFile.target = target}
                                error = await spiprojCodeActionExecuteReq(uri,x[1])
                                if (!error) {
                                    const edit = new WorkspaceEdit()
                                    edit.replace(doc.uri,r,target)
                                    workspace.applyEdit(edit)
                                    }
                                }
                        }
                        if ("DeleteFile" in x[1] || "DeleteDirectory" in x[1]) {
                            const target = await window.showInputBox({prompt: "Enter 'y' to confirm the delete."})
                            if (target === "y") { 
                                error = await spiprojCodeActionExecuteReq(uri,x[1])
                                if (!error) {
                                    const edit = new WorkspaceEdit()
                                    if ("DeleteDirectory" in x[1]) {edit.delete(doc.uri,range(x[1].DeleteDirectory.range))}
                                    else {edit.delete(doc.uri,range(x[1].DeleteFile.range))}
                                    workspace.applyEdit(edit)
                                    }
                                }
                        }
                        if (error) {window.showErrorMessage(error)}
                    }]}
                    return a
                    })
        }
    }

    const serverToClientMsgHandler = (x : any) => {
        const msg: ClientRes = JSON.parse(x.toString())
        if ("PackageErrors" in msg) { errorsSet(errorsProject, Uri.parse(msg.PackageErrors.uri,true), msg.PackageErrors.errors) }
        else if ("TokenizerErrors" in msg) { errorsSet(errorsTokenization, Uri.parse(msg.TokenizerErrors.uri,true), msg.TokenizerErrors.errors) }
        else if ("ParserErrors" in msg) { errorsSet(errorsParse, Uri.parse(msg.ParserErrors.uri,true), msg.ParserErrors.errors) }
        else if ("TypeErrors" in msg) { errorsSet(errorsType, Uri.parse(msg.TypeErrors.uri,true), msg.TypeErrors.errors) }
        else if ("FatalError" in msg) { window.showErrorMessage(msg.FatalError) }
        else if ("TracedError" in msg) { 
            const max0 = (x : number) => 0 <= x ? x : 0
            const {trace, message} = msg.TracedError
            const traceLength : number | undefined = workspace.getConfiguration("spiral").get("errorTraceMaxLength")
            const from = max0(trace.length-(traceLength === undefined ? 5 : max0(traceLength)))
            trace.push(message)
            window.showErrorMessage(trace.slice(from).join(""))
            }
        else { const _ : never = msg }
    }

    const serverDisposables = new SerialDisposable(() => {})

    const startServer = async (hideFromUser: boolean, isRestart : boolean = false) => {
        serverDisposables.assign(() => {
            prev_request = new Promise(resolve => resolve(null))
            terminal.dispose()
            errorsProject.clear(); errorsTokenization.clear(); errorsParse.clear(); errorsType.clear()
        })


        const terminal = window.createTerminal({name: "Spiral Server", hideFromUser})
        const compiler_path = path.join(__dirname,"../compiler/Spiral.dll")
        if (isRestart) { await sleep(1000) }
        const config  = workspace.getConfiguration("spiral")
        const default_int : string = config.get("default_int") || "i32"
        const default_float : string = config.get("default_float") || "f64"
        terminal.sendText(`dotnet "${compiler_path}" --port ${port} --default_int ${default_int} --default_float ${default_float}`)
    }
    
    await startServer(workspace.getConfiguration("spiral").get("hideTerminal") || false, false)
    await hubStart()
    hub.on("ServerToClientMsg",serverToClientMsgHandler)
    hub.onreconnected(() => {
        workspace.textDocuments.forEach(onDocOpen)
    })
    workspace.textDocuments.forEach(onDocOpen)

    const spiralFilePattern = {pattern: '**/*.{spi,spir}'}
    const spiralProjFilePattern = {pattern: '**/package.spiproj'}
    const spiralTokenLegend = ['variable','symbol','string','number','operator','unary_operator','comment','keyword','parenthesis','type_variable','escaped_char','unescaped_char','number_suffix']
    ctx.subscriptions.push(
        serverDisposables,
        errorsProject, errorsTokenization, errorsParse, errorsType,
        workspace.onDidOpenTextDocument(onDocOpen),
        workspace.onDidChangeTextDocument(onDocChange),
        workspace.onDidRenameFiles(onRename),
        workspace.onDidDeleteFiles(onDelete),
        languages.registerDocumentRangeSemanticTokensProvider(spiralFilePattern,new SpiralTokens(),new SemanticTokensLegend(spiralTokenLegend)),
        languages.registerHoverProvider(spiralFilePattern,new SpiralHover()),
        commands.registerCommand("buildFile", () => {
            window.visibleTextEditors.forEach(x => {
                switch (path.extname(x.document.uri.path)) {
                    case ".spi": case ".spir": {
                        const config = workspace.getConfiguration("spiral")
                        const backend : string = config.get("backend") || "Fsharp"
                        spiBuildFileReq(x.document.uri.toString(true), backend)
                    }
                }})
        }),
        commands.registerCommand("runClosure", x => x() ),
        commands.registerCommand("startServer", () => startServer(false, true) ),
        commands.registerCommand("startServerHidden", () => startServer(true, true) ),
        commands.registerCommand("showConnectionStatus", () => window.showInformationMessage(JSON.stringify(hub.connectionId)) ),
        languages.registerDocumentLinkProvider(spiralProjFilePattern,new SpiralProjectLinks()),
        languages.registerCodeActionsProvider(spiralProjFilePattern,new SpiralProjectCodeActions())
    )
}