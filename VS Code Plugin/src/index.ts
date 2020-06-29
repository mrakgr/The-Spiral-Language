import * as path from "path"
import { window, ExtensionContext, languages, workspace, DiagnosticCollection, TextDocument, Diagnostic, DiagnosticSeverity, tasks, RelativePattern, Position, Range, TextDocumentContentChangeEvent, SemanticTokens, CancellationToken, SemanticTokensLegend, DocumentSemanticTokensProvider, EventEmitter } from "vscode"
import * as zmq from "zeromq"

const uri = "tcp://localhost:13805"

const request = async (file: object) => {
    const sock = new zmq.Request()
    sock.connect(uri)
    await sock.send(JSON.stringify(file))
    const [x] = await sock.receive()
    return JSON.parse(x.toString())
}

const spiproj = async (spiprojDir: string, spiprojText: string) => request({ ProjectFile: { spiprojDir, spiprojText } })
const spi = async (spiPath: string, spiText: string) => request({ FileOpen: { spiPath, spiText } })

type Result<a, b> = { Ok: a } | { Error: b }
const matchResult = <a, b, r>(x: Result<a, b>, onOk: (arg: a) => r, onError: (arg: b) => r): r => {
    if ("Ok" in x) { return onOk(x.Ok) }
    else if ("Error" in x) { return onError(x.Error) }
    else { throw "Expected a result type" }
}

type PositionRec = { line: number, character: number }
type RangeRec = [PositionRec, PositionRec]
export const activate = async (ctx: ExtensionContext) => {
    window.showInformationMessage("Spiral plugin is active.")
    
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
        matchResult(await spiproj(project_path, doc.getText()),
            () => errors.set(doc.uri, []),
            errorsSet(doc)
        )
    }

    let tokens = new Map<string,SemanticTokens>()
    const tokenChange = new EventEmitter<void>()
    const tokenChangeEvent = tokenChange.event
    const spiOpen = async (doc: TextDocument) => {
        const x : [number [], [string, RangeRec][]] = await spi(doc.uri.fsPath, doc.getText())
        window.showInformationMessage(`Data: ${JSON.stringify(x)}`)
        tokens.set(doc.uri.fsPath,new SemanticTokens(new Uint32Array(x[0])))
        tokenChange.fire()
        errorsSet(doc)(x[1])
    }

    class SpiralTokens implements DocumentSemanticTokensProvider {
        onDidChangeSemanticTokens = tokenChangeEvent
        provideDocumentSemanticTokens(doc: TextDocument): SemanticTokens {
            return tokens.get(doc.uri.fsPath) || new SemanticTokens(new Uint32Array())
        }
    }

    ctx.subscriptions.push(
        errors,
        workspace.onDidChangeTextDocument(x => {
            const doc = x.document
            switch (path.extname(doc.uri.path)) {
                case ".spiproj": return spiprojOpen(doc)
                case ".spi": return spiOpen(doc)
                default: return
            }
        }),
        languages.registerDocumentSemanticTokensProvider(
            { language: 'spiral'}, 
            new SpiralTokens(),
            new SemanticTokensLegend(['variable','symbol','string','value','operator','unary operator','comment','keyword','bracket'])
            )
    )
}