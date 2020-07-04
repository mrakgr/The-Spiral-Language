import * as path from "path"
import { window, ExtensionContext, languages, workspace, DiagnosticCollection, TextDocument, Diagnostic, DiagnosticSeverity, tasks, Position, Range, TextDocumentContentChangeEvent, SemanticTokens, SemanticTokensLegend, DocumentSemanticTokensProvider, EventEmitter, SemanticTokensBuilder, DocumentRangeSemanticTokensProvider, SemanticTokensEdits, TextDocumentChangeEvent, SemanticTokensEdit } from "vscode"
import * as zmq from "zeromq"

const uri = "tcp://localhost:13805"

const request = async (file: object) => {
    const sock = new zmq.Request()
    sock.connect(uri)
    await sock.send(JSON.stringify(file))
    const [x] = await sock.receive()
    return JSON.parse(x.toString())
}

const spiprojOpenReq = async (spiprojDir: string, spiprojText: string) => request({ ProjectFileOpen: { spiprojDir, spiprojText } })
const spiOpenReq = async (spiPath: string, spiText: string) => request({ FileOpen: { spiPath, spiText } })
const spiChangeReq = async (spiPath: string, spiEdits : {from: number, nearTo: number, lines: string[]} []) => request({ FileChanged: { spiPath, spiEdits } })
const spiTokenAllReq = async (spiPath: string) => request({ FileTokenAll: { spiPath } })
const spiTokenChangesReq = async (spiPath: string) => request({ FileTokenChanges: { spiPath } })

type Result<a, b> = { Ok: a } | { Error: b }
const matchResult = <a, b, r>(x: Result<a, b>, onOk: (arg: a) => r, onError: (arg: b) => r): r => {
    if ("Ok" in x) { return onOk(x.Ok) }
    else if ("Error" in x) { return onError(x.Error) }
    else { throw "Expected a result type" }
}

type PositionRec = { line: number, character: number }
type RangeRec = [PositionRec, PositionRec]
export const activate = async (ctx: ExtensionContext) => {
    console.log("Spiral plugin is active.")
    
    const errors = languages.createDiagnosticCollection()
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
        errors.set(doc.uri, diag)
    }

    const spiprojOpen = async (doc: TextDocument) => {
        errorsSet(doc)(await spiprojOpenReq(path.dirname(doc.uri.fsPath), doc.getText()))
    }

    const tokenChange = new EventEmitter<void>()
    const tokenChangeEvent = tokenChange.event
    const spiOpen = async (doc: TextDocument) => {
        errorsSet(doc)(await spiOpenReq(doc.uri.fsPath, doc.getText()))
        tokenChange.fire()
    }

    const numberOfLines = (str: string) => {
        var length = 1;
        for (var i = 0; i < str.length; i++) { if (str[i] == '\n') { length++; } }
        return length;
    }

    const spiChange = async (doc : TextDocument, changes: readonly TextDocumentContentChangeEvent[]) => {
        const edits = changes.map(x => {
            const from = x.range.start.line
            const nearTo = from + numberOfLines(x.text)
            const lines : string [] = []
            for (let i = from; i < nearTo; i++) { lines.push(doc.lineAt(i).text) }
            return {lines, from, nearTo: x.range.end.line+1}
        })
        errorsSet(doc)(await spiChangeReq(doc.uri.fsPath, edits))
        tokenChange.fire()
    }

    class SpiralTokens implements DocumentSemanticTokensProvider {
        onDidChangeSemanticTokens = tokenChangeEvent
        async provideDocumentSemanticTokens(doc: TextDocument) {
            const x : number [] = await spiTokenAllReq(doc.uri.fsPath)
            return new SemanticTokens(new Uint32Array(x),"")
        } 
        async provideDocumentSemanticTokensEdits(doc: TextDocument) { 
            const x : [number, number, number []][] = await spiTokenChangesReq(doc.uri.fsPath)
            return new SemanticTokensEdits(x.map(x => new SemanticTokensEdit(x[0],x[1],new Uint32Array(x[2]))),"")
        }
    }

    const onDocOpen = (doc: TextDocument) => {
        switch (path.extname(doc.uri.path)) {
            case ".spiproj": return spiprojOpen(doc)
            case ".spi": return spiOpen(doc)
            default: return
        }
    }
    const onDocChange = (x: TextDocumentChangeEvent) => {
        switch (path.extname(x.document.uri.path)) {
            case ".spiproj": return spiprojOpen(x.document)
            case ".spi": return spiChange(x.document,x.contentChanges)
            default: return
        }
    }

    workspace.textDocuments.forEach(onDocOpen)
    ctx.subscriptions.push(
        errors,
        workspace.onDidOpenTextDocument(onDocOpen),
        workspace.onDidChangeTextDocument(onDocChange),
        languages.registerDocumentSemanticTokensProvider(
            { language: 'spiral'}, 
            new SpiralTokens(),
            new SemanticTokensLegend(['variable','symbol','string','number','operator','unary_operator','comment','keyword','bracket'])
            )
    )
}