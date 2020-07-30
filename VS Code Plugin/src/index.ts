import * as path from "path"
import { window, ExtensionContext, languages, workspace, DiagnosticCollection, TextDocument, Diagnostic, DiagnosticSeverity, tasks, Position, Range, TextDocumentContentChangeEvent, SemanticTokens, SemanticTokensLegend, DocumentSemanticTokensProvider, EventEmitter, SemanticTokensBuilder, DocumentRangeSemanticTokensProvider, SemanticTokensEdits, TextDocumentChangeEvent, SemanticTokensEdit } from "vscode"
import * as zmq from "zeromq"

const uri = "tcp://localhost:13805"

let msgId = 0
const request = async (file: object) => {
    const sock = new zmq.Request()
    sock.connect(uri)
    await sock.send(JSON.stringify([msgId++, file]))
    const [x] = await sock.receive()
    return JSON.parse(x.toString())
}

const spiprojOpenReq = async (spiprojDir: string, spiprojText: string) => request({ ProjectFileOpen: { spiprojDir, spiprojText } })
const spiOpenReq = async (spiPath: string, spiText: string) => request({ FileOpen: { spiPath, spiText } })
const spiChangeReq = async (spiPath: string, spiEdits : {from: number, nearTo: number, lines: string[]} ) => request({ FileChanged: { spiPath, spiEdits } })
const spiTokenRangeReq = async (spiPath: string, range : Range) => request({ FileTokenRange: { spiPath, range } })

type PositionRec = { line: number, character: number }
type RangeRec = [PositionRec, PositionRec]
export const activate = async (ctx: ExtensionContext) => {
    console.log("Spiral plugin is active.")
    
    const errorsParse = languages.createDiagnosticCollection()
    const errorsType = languages.createDiagnosticCollection()
    const errorsSet = (doc: TextDocument) => (x: [string, RangeRec | null][]) => {
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
        errorsParse.set(doc.uri, diag)
    }

    const spiprojOpen = async (doc: TextDocument) => {
        errorsSet(doc)(await spiprojOpenReq(path.dirname(doc.uri.fsPath), doc.getText()))
    }

    const spiOpen = async (doc: TextDocument) => {
        errorsSet(doc)(await spiOpenReq(doc.uri.fsPath, doc.getText()))
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
            errorsSet(doc)(await spiChangeReq(doc.uri.fsPath, edit))
        }
    }

    class SpiralTokens implements DocumentRangeSemanticTokensProvider {
        async provideDocumentRangeSemanticTokens(doc: TextDocument, range : Range) {
            const x : number [] = await spiTokenRangeReq(doc.uri.fsPath, range)
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
        errorsParse, errorsType,
        workspace.onDidOpenTextDocument(onDocOpen),
        workspace.onDidChangeTextDocument(onDocChange),
        languages.registerDocumentRangeSemanticTokensProvider(
            { language: 'spiral'}, 
            new SpiralTokens(),
            new SemanticTokensLegend(['variable','symbol','string','number','operator','unary_operator','comment','keyword','parenthesis','type_variable'])
            )
    )
}