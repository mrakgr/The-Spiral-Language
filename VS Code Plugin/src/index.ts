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
const spiChangeReq = async (spiPath: string, spiChangedLines : [number, string] []) => request({ FileChanged: { spiPath, spiChangedLines } })

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
        const project_path = path.dirname(doc.uri.fsPath)
        matchResult(await spiprojOpenReq(project_path, doc.getText()),
            () => errors.set(doc.uri, []),
            errorsSet(doc)
        )
    }

    type TokensOrEdits = {tokens: SemanticTokens} | {edits: SemanticTokensEdits}
    let tokens = new Map<string,TokensOrEdits>()
    const tokenChange = new EventEmitter<void>()
    const tokenChangeEvent = tokenChange.event
    const spiOpen = async (doc: TextDocument) => {
        const x : [number [], [string, RangeRec][]] = await spiOpenReq(doc.uri.fsPath, doc.getText())
        tokens.set(doc.uri.fsPath,{tokens: new SemanticTokens(new Uint32Array(x[0]),"")})
        tokenChange.fire()
        errorsSet(doc)(x[1])
    }
    const spiChange = async (doc : TextDocument, changes: readonly TextDocumentContentChangeEvent[]) => {
        const linesSet = new Set<number>()
        changes.forEach(x => {
            const from = x.range.start.line
            const to = x.range.end.line
            for (let i = from; i <= to; i++) { linesSet.add(i) }
        })
        const lines : [number,string] [] = []
        linesSet.forEach(i => lines.push([i,doc.lineAt(i).text])) // TODO: Figure out what happens when lineAt is out of bounds.
        lines.sort((a,b) => a[0]-b[0])

        const x : [[number, number, number[]] [], [string, RangeRec][]] = await spiChangeReq(doc.uri.fsPath, lines)
        tokens.set(doc.uri.fsPath,{edits: new SemanticTokensEdits(x[0].map(x => new SemanticTokensEdit(x[0],x[1],new Uint32Array(x[2]))),"")})
        tokenChange.fire()
        errorsSet(doc)(x[1])
    }

    const tokensMapDelete = (f : (x : TokensOrEdits | undefined) => any) => (doc : TextDocument) => {
        const x = tokens.get(doc.uri.fsPath)
        if (x) {tokens.delete(doc.uri.fsPath)}
        return f(x)
    }

    class SpiralTokens implements DocumentSemanticTokensProvider {
        onDidChangeSemanticTokens = tokenChangeEvent
        provideDocumentSemanticTokens = tokensMapDelete(x => (x && "tokens" in x) ? x.tokens : new SemanticTokens(new Uint32Array()))
        provideDocumentSemanticTokensEdits = tokensMapDelete(x => x ? (("tokens" in x) ? x.tokens : x.edits) : new SemanticTokens(new Uint32Array()))
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