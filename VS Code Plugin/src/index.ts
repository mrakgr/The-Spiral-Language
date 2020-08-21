import * as path from "path"
import { window, ExtensionContext, languages, workspace, DiagnosticCollection, TextDocument, Diagnostic, DiagnosticSeverity, tasks, Position, Range, TextDocumentContentChangeEvent, SemanticTokens, SemanticTokensLegend, DocumentSemanticTokensProvider, EventEmitter, SemanticTokensBuilder, DocumentRangeSemanticTokensProvider, SemanticTokensEdits, TextDocumentChangeEvent, SemanticTokensEdit, Uri, CancellationToken, CancellationTokenSource, Disposable } from "vscode"
import * as zmq from "zeromq"

const port = 13805
const uriServer = `tcp://localhost:${port}`
const uriClient = `tcp://*:${port+1}`

let msgId = 0
const request = async (file: object) => {
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
    { ParserErrors: {uri : string, errors : [string, RangeRec][]}}

export const activate = async (ctx: ExtensionContext) => {
    console.log("Spiral plugin is active.")

    const errorsParse = languages.createDiagnosticCollection()
    const errorsType = languages.createDiagnosticCollection()
    let isProcessing = true;
    (async () => {
        const sock = new zmq.Reply()
        sock.receiveTimeout = 2000
        sock.sendTimeout = 2000
        await sock.bind(uriClient)
        try {
            while (isProcessing) {
                try {
                    const [x] = await sock.receive()
                    const msg: ClientRes = JSON.parse(x.toString())
                    if ("ParserErrors" in msg) {
                        errorsSet(errorsParse, Uri.parse(msg.ParserErrors.uri), msg.ParserErrors.errors)
                    }
                    sock.send(null)
                } catch (e) {
                    if (e.errno === 11) { } // If the error is a timeout just repeat.
                    else { throw e }
                }
            }
        } finally {
            await sock.unbind(uriServer)
        }
    })();

    const errorsTokenization = languages.createDiagnosticCollection()
    const spiprojOpen = async (doc: TextDocument) => {
        errorsSet(errorsTokenization, doc.uri, await spiprojOpenReq(doc.uri.toString(), doc.getText()))
    }

    const spiOpen = async (doc: TextDocument) => {
        errorsSet(errorsTokenization, doc.uri, await spiOpenReq(doc.uri.toString(), doc.getText()))
    }

    const numberOfLines = (str: string) => {
        var length = 1;
        for (var i = 0; i < str.length; i++) { if (str[i] == '\n') { length++; } }
        return length;
    }

    const spiChange = async (doc : TextDocument, changes: readonly TextDocumentContentChangeEvent[]) => {
        if (1 < changes.length) {
            await spiOpen(doc)
        } else if (1 === changes.length) {
            const x = changes[0]
            const from = x.range.start.line
            const nearTo = from + numberOfLines(x.text)
            const lines : string [] = []
            for (let i = from; i < nearTo; i++) { lines.push(doc.lineAt(i).text) }
            const edit = {lines, from, nearTo: x.range.end.line+1}
            errorsSet(errorsTokenization, doc.uri, await spiChangeReq(doc.uri.toString(), edit))
        }
    }

    class SpiralTokens implements DocumentRangeSemanticTokensProvider {
        async provideDocumentRangeSemanticTokens(doc: TextDocument, range : Range) {
            const x : number [] = await spiTokenRangeReq(doc.uri.toString(), range)
            return new SemanticTokens(new Uint32Array(x),"")
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

    workspace.textDocuments.forEach(onDocOpen)
    ctx.subscriptions.push(
        new Disposable(() => {isProcessing = false}),
        errorsTokenization, errorsParse, errorsType,
        workspace.onDidOpenTextDocument(onDocOpen),
        workspace.onDidChangeTextDocument(onDocChange),
        languages.registerDocumentRangeSemanticTokensProvider(
            { pattern: '**/*.{spi,spir}'}, 
            new SpiralTokens(),
            new SemanticTokensLegend(['variable','symbol','string','number','operator','unary_operator','comment','keyword','parenthesis','type_variable'])
            )
    )
}