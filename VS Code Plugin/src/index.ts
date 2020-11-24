import * as path from "path"
import * as _ from "lodash"
import { window, ExtensionContext, languages, workspace, DiagnosticCollection, TextDocument, Diagnostic, DiagnosticSeverity, tasks, Position, Range, TextDocumentContentChangeEvent, SemanticTokens, SemanticTokensLegend, DocumentSemanticTokensProvider, EventEmitter, SemanticTokensBuilder, DocumentRangeSemanticTokensProvider, SemanticTokensEdits, TextDocumentChangeEvent, SemanticTokensEdit, Uri, CancellationToken, CancellationTokenSource, Disposable, HoverProvider, Hover, MarkdownString, commands, DocumentLinkProvider, DocumentLink, CodeAction, CodeActionProvider, WorkspaceEdit, FileDeleteEvent } from "vscode"
import * as zmq from "zeromq"

const port = 13805
const uriServer = `tcp://localhost:${port}`
const uriClient = `tcp://*:${port+1}`

let msgId = 0
const request = async (file: object): Promise<any> => {
    const sock = new zmq.Request()
    sock.connect(uriServer)
    await sock.send(JSON.stringify([msgId++, file]))
    const [x] = await sock.receive()
    return JSON.parse(x.toString())
}

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

const spiprojOpenReq = async (uri: string, spiprojText: string): Promise<void> => request({ ProjectFileOpen: { uri, spiprojText } })
const spiprojChangeReq = async (uri: string, spiprojText: string): Promise<void> => request({ ProjectFileChange: { uri, spiprojText } })
const spiprojDeleteReq = async (uri: string): Promise<void> => request({ ProjectFileDelete: { uri } })
const spiprojLinksReq = async (uri: string): Promise<RString []> => request({ ProjectFileLinks: { uri } })
const spiprojCodeActionsReq = async (uri: string): Promise<RAction []> => request({ ProjectCodeActions: { uri } })
const spiprojCodeActionExecuteReq = async (uri: string, action : ProjectCodeAction): Promise<string | null> => request({ ProjectCodeActionExecute: { uri, action } }).then(x => x.result)

const spiOpenReq = async (uri: string, spiText: string): Promise<void> => request({ FileOpen: { uri, spiText } })
const spiChangeReq = async (uri: string, spiEdit : {from: number, nearTo: number, lines: string[]} ): Promise<void> => 
    request({ FileChange: { uri, spiEdit } })
const spiDeleteReq = async (uri: string): Promise<void> => request({ FileDelete: { uri } })
const spiTokenRangeReq = async (uri: string, range : Range): Promise<number []> => request({ FileTokenRange: { uri, range } })
const spiHoverAtReq = async (uri: string, pos : Position): Promise<string | null> => request({ HoverAt: { uri, pos } })
const spiBuildFileReq = async (uri: string): Promise<void> => request({ BuildFile: {uri} })

const range = (x : VSCRange) => new Range(x[0].line, x[0].character, x[1].line, x[1].character)

const errorsSet = (errors : DiagnosticCollection, uri: Uri, x: RString[]) => {
    errors.set(uri, x.map(([r, er]) => new Diagnostic(range(r), er, DiagnosticSeverity.Error)))
}

type Errors = {uri : string; errors : RString[]}
type ClientRes = 
    | { FatalError: string }
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

type SpiralAction = {range : Range; action : CodeAction}

export const activate = async (ctx: ExtensionContext) => {
    console.log("Spiral plugin is active.")

    const errorsProject = languages.createDiagnosticCollection()
    const errorsTokenization = languages.createDiagnosticCollection()
    const errorsParse = languages.createDiagnosticCollection()
    const errorsType = languages.createDiagnosticCollection()
    let isProcessing = true;
    (async () => {
        const sock = new zmq.Reply()
        sock.receiveTimeout = 2000
        sock.sendTimeout = 2000
        await sock.bind(uriClient)
        while (isProcessing) {
            try {
                const [x] = await sock.receive()
                const msg: ClientRes = JSON.parse(x.toString())
                if ("PackageErrors" in msg) { errorsSet(errorsProject, Uri.parse(msg.PackageErrors.uri), msg.PackageErrors.errors) }
                else if ("TokenizerErrors" in msg) { errorsSet(errorsTokenization, Uri.parse(msg.TokenizerErrors.uri), msg.TokenizerErrors.errors) }
                else if ("ParserErrors" in msg) { errorsSet(errorsParse, Uri.parse(msg.ParserErrors.uri), msg.ParserErrors.errors) }
                else if ("TypeErrors" in msg) { errorsSet(errorsType, Uri.parse(msg.TypeErrors.uri), msg.TypeErrors.errors) }
                else if ("FatalError" in msg) { window.showErrorMessage(msg.FatalError) }
                else { const _ : never = msg }
                sock.send(null)
            } catch (e) {
                if (e.errno === 11) { } // If the error is a timeout just repeat.
                else { throw e }
            }
        }
        await sock.unbind(uriServer)
    })();

    const spiprojOpen = (doc: TextDocument) => spiprojOpenReq(doc.uri.toString(true), doc.getText())
    const spiprojChange = (doc: TextDocument) => spiprojChangeReq(doc.uri.toString(true), doc.getText())
    const spiprojDelete = (uri: Uri) => spiprojDeleteReq(uri.toString(true))
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
    const spiDelete = (uri: Uri) => spiDeleteReq(uri.toString(true))

    class SpiralTokens implements DocumentRangeSemanticTokensProvider {
        async provideDocumentRangeSemanticTokens(doc: TextDocument, range : Range) {
            const x = await spiTokenRangeReq(doc.uri.toString(true), range)
            return new SemanticTokens(new Uint32Array(x),"")
        }
    }

    class SpiralHover implements HoverProvider {
        async provideHover(document: TextDocument, position: Position) {
            const x = await spiHoverAtReq(document.uri.toString(true),position)
            if (x) return new Hover(new MarkdownString().appendCodeblock(x,'plaintext'))
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

    const onDelete = (e: FileDeleteEvent) => {
        e.files.forEach(x => {
            switch (path.extname(x.path)) {
                case ".spiproj": 
                    if (path.basename(x.path,".spiproj") === "package") { spiprojDelete(x) }
                    return
                case ".spir": case ".spi": return spiDelete(x)
                default: return
            }
        })
    }

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

    const spiralFilePattern = { pattern: '**/*.{spi,spir}'}
    const spiralProjFilePattern = { pattern: '**/package.spiproj'}
    const spiralTokenLegend = ['variable','symbol','string','number','operator','unary_operator','comment','keyword','parenthesis','type_variable','escaped_char','unescaped_char']
    workspace.textDocuments.forEach(onDocOpen)
    ctx.subscriptions.push(
        new Disposable(() => {isProcessing = false}),
        errorsProject, errorsTokenization, errorsParse, errorsType,
        workspace.onDidOpenTextDocument(onDocOpen),
        workspace.onDidChangeTextDocument(onDocChange),
        workspace.onDidDeleteFiles(onDelete),
        languages.registerDocumentRangeSemanticTokensProvider(spiralFilePattern,new SpiralTokens(),new SemanticTokensLegend(spiralTokenLegend)),
        languages.registerHoverProvider(spiralFilePattern,new SpiralHover()),
        commands.registerCommand("buildFile", () => {
            window.visibleTextEditors.forEach(x => spiBuildFileReq(x.document.uri.toString(true)))
        }),
        commands.registerCommand("runClosure", x => { x() }),
        languages.registerDocumentLinkProvider(spiralProjFilePattern,new SpiralProjectLinks()),
        languages.registerCodeActionsProvider(spiralProjFilePattern,new SpiralProjectCodeActions())
    )
}