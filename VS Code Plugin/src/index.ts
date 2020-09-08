import * as path from "path"
import * as _ from "lodash"
import { window, ExtensionContext, languages, workspace, DiagnosticCollection, TextDocument, Diagnostic, DiagnosticSeverity, tasks, Position, Range, TextDocumentContentChangeEvent, SemanticTokens, SemanticTokensLegend, DocumentSemanticTokensProvider, EventEmitter, SemanticTokensBuilder, DocumentRangeSemanticTokensProvider, SemanticTokensEdits, TextDocumentChangeEvent, SemanticTokensEdit, Uri, CancellationToken, CancellationTokenSource, Disposable, HoverProvider, Hover, MarkdownString } from "vscode"
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

const spiprojOpenReq = async (uri: string, spiprojText: string) => request({ ProjectFileOpen: { uri, spiprojText } })
const spiOpenReq = async (uri: string, spiText: string) => request({ FileOpen: { uri, spiText } })
const spiChangeReq = async (uri: string, spiEdit : {from: number, nearTo: number, lines: string[]} ) => request({ FileChanged: { uri, spiEdit } })
const spiTokenRangeReq = async (uri: string, range : Range) => request({ FileTokenRange: { uri, range } })
const spiHoverAtReq = async (uri: string, pos : Position) => request({ HoverAt: { uri, pos } })

const errorsSet = (errors : DiagnosticCollection, uri: Uri, x: [string, RangeRec | null][]) => {
    const diag: Diagnostic[] = []
    x.forEach(([error, range]) => {
        if (range) {
            diag.push(new Diagnostic(
                new Range(range[0].line, range[0].character, range[1].line, range[1].character),
                error, DiagnosticSeverity.Error))
        } else {
            window.showErrorMessage(error)
        }
    })
    errors.set(uri, diag)
}

type PositionRec = { line: number, character: number }
type RangeRec = [PositionRec, PositionRec]
type ClientRes = 
    { ProjectErrors: {uri : string, errors : [string, RangeRec | null][]} }
    | { TokenizerErrors: {uri : string, errors : [string, RangeRec][]}}
    | { ParserErrors: {uri : string, errors : [string, RangeRec][]}}
    | { TypeErrors: {uri : string, errors : [string, RangeRec][]}}


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
                if ("ProjectErrors" in msg) {
                    errorsSet(errorsProject, Uri.parse(msg.ProjectErrors.uri), msg.ProjectErrors.errors)
                }
                if ("TokenizerErrors" in msg) {
                    errorsSet(errorsTokenization, Uri.parse(msg.TokenizerErrors.uri), msg.TokenizerErrors.errors)
                }
                if ("ParserErrors" in msg) {
                    errorsSet(errorsParse, Uri.parse(msg.ParserErrors.uri), msg.ParserErrors.errors)
                }
                if ("TypeErrors" in msg) {
                    errorsSet(errorsType, Uri.parse(msg.TypeErrors.uri), msg.TypeErrors.errors)
                }
                sock.send(null)
            } catch (e) {
                if (e.errno === 11) { } // If the error is a timeout just repeat.
                else { throw e }
            }
        }
        await sock.unbind(uriServer)
    })();

    const spiprojOpen = (doc: TextDocument) => { spiprojOpenReq(doc.uri.toString(), doc.getText()) }
    const spiOpen = (doc: TextDocument) => { spiOpenReq(doc.uri.toString(), doc.getText()) }

    const numberOfLinesAdded = (str: string) => {
        var length = 0;
        for (var i = 0; i < str.length; i++) { if (str[i] == '\n') { length++; } }
        return length;
    }

    const spiChange = async (doc : TextDocument, changes: readonly TextDocumentContentChangeEvent[]) => {
        if (0 < changes.length) {
            const sortedChanges = 1 < changes.length ? _.sortBy(changes,x => [x.range.start.line, x.range.start.character]) : changes
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
            spiChangeReq(doc.uri.toString(), edit)
        }
    }

    class SpiralTokens implements DocumentRangeSemanticTokensProvider {
        async provideDocumentRangeSemanticTokens(doc: TextDocument, range : Range) {
            const x : number [] = await spiTokenRangeReq(doc.uri.toString(), range)
            return new SemanticTokens(new Uint32Array(x),"")
        }
    }

    class SpiralHover implements HoverProvider {
        async provideHover(document: TextDocument, position: Position) {
            const x : string | null = await spiHoverAtReq(document.uri.toString(),position)
            if (x) return new Hover(new MarkdownString().appendCodeblock(x,'plaintext'))
        }
    }

    const onDocOpen = (doc: TextDocument) => {
        switch (path.extname(doc.uri.path)) {
            case ".spiproj": return spiprojOpen(doc)
            case ".spir":
            case ".spi": return spiOpen(doc)
            default: return
        }
    }
    const onDocChange = (x: TextDocumentChangeEvent) => {
        switch (path.extname(x.document.uri.path)) {
            case ".spiproj": return spiprojOpen(x.document)
            case ".spir":
            case ".spi": return spiChange(x.document,x.contentChanges)
            default: return
        }
    }

    const spiralFilePattern = { pattern: '**/*.{spi,spir}'}
    const spiralTokenLegend = ['variable','symbol','string','number','operator','unary_operator','comment','keyword','parenthesis','type_variable','escaped_char','unescaped_char']
    workspace.textDocuments.forEach(onDocOpen)
    ctx.subscriptions.push(
        new Disposable(() => {isProcessing = false}),
        errorsProject, errorsTokenization, errorsParse, errorsType,
        workspace.onDidOpenTextDocument(onDocOpen),
        workspace.onDidChangeTextDocument(onDocChange),
        languages.registerDocumentRangeSemanticTokensProvider(spiralFilePattern,new SpiralTokens(),new SemanticTokensLegend(spiralTokenLegend)),
        languages.registerHoverProvider(spiralFilePattern,new SpiralHover())
    )
}