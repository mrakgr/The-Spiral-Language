import * as path from "path";
import { window, ExtensionContext, languages, workspace, DiagnosticCollection, TextDocument, Diagnostic, DiagnosticSeverity, tasks, RelativePattern, Position, Range } from "vscode";
import * as zmq from "zeromq";

type CfgPos = { Line: number, Column: number }
type CfgRange = { Start: CfgPos, End: CfgPos }
type Schema = {
    dirSource : string
    dirOut : string
    name : string
    version : string
    files : string []
}

const uri = "tcp://localhost:13805";

const client = async (spiprojDir: string, spiprojText: string) => {
    const sock = new zmq.Request();
    sock.connect(uri);
    await sock.send(JSON.stringify({ ProjectFile: {spiprojDir, spiprojText} }));
    const [x] = await sock.receive();
    return JSON.parse(x.toString());
};

type Result<a,b> = {Ok: a} | {Error: b}
const matchResult = <a,b,r>(x : Result<a,b>, onOk : (arg: a) => r, onError : (arg : b) => r): r => {
    if ("Ok" in x) { return onOk(x.Ok); }
    else if ("Error" in x) { return onError(x.Error); }
    else {throw "Expected a result type";}
};

export const activate = async (ctx: ExtensionContext) => {
    window.showInformationMessage("Spiral plugin is active.");

    const config_errors = languages.createDiagnosticCollection();
    const spiproj_process = async (doc : TextDocument) => {
        const project_path = path.dirname(doc.uri.fsPath);
        matchResult(await client(project_path, doc.getText()),
            (x : Schema) => {
                config_errors.set(doc.uri, [])
                },
            (x : [string, CfgRange | null][]) => {
                const diag : Diagnostic [] = [];
                x.forEach(([error, range]) => {
                    if (range) {
                        const { Start, End } = range;
                        diag.push(new Diagnostic(
                            new Range(Start.Line, Start.Column, End.Line, End.Column),
                            error,
                            DiagnosticSeverity.Error))
                    } else {
                        window.showErrorMessage(error)
                    }
                });
                config_errors.set(doc.uri,diag)
            }
        )
    }

    ctx.subscriptions.push(
        config_errors,
        workspace.onDidChangeTextDocument(x => path.extname(x.document.uri.path) === ".spiproj" ? spiproj_process(x.document) : undefined)
    );
};