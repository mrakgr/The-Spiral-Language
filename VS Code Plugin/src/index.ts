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

const request = async (file : object) => {
    const sock = new zmq.Request();
    sock.connect(uri);
    await sock.send(JSON.stringify(file));
    const [x] = await sock.receive();
    return JSON.parse(x.toString());
};

const spiproj = async (spiprojDir: string, spiprojText: string) => request({ ProjectFile: {spiprojDir, spiprojText} });
const spi = async (spiPath: string, spiText: string) => request({ File: {spiPath, spiText} });

type Result<a,b> = {Ok: a} | {Error: b}
const matchResult = <a,b,r>(x : Result<a,b>, onOk : (arg: a) => r, onError : (arg : b) => r): r => {
    if ("Ok" in x) { return onOk(x.Ok); }
    else if ("Error" in x) { return onError(x.Error); }
    else {throw "Expected a result type";}
};

export const activate = async (ctx: ExtensionContext) => {
    window.showInformationMessage("Spiral plugin is active.");

    const config_errors = languages.createDiagnosticCollection();
    const spiprojProcess = async (doc : TextDocument) => {
        const project_path = path.dirname(doc.uri.fsPath);
        matchResult(await spiproj(project_path, doc.getText()),
            () => {
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

    // TODO: I'll abstract this later, right now I am just testing whether it works at all.
    const spiProcess = async (doc : TextDocument) => { 
        const file_path = doc.uri.fsPath;
        matchResult(await spi(file_path, doc.getText()),
            () => {
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
        workspace.onDidChangeTextDocument(x => {
            switch (path.extname(x.document.uri.path)) {
                case ".spiproj": return spiprojProcess(x.document);
                case ".spi": return spiProcess(x.document);
                default: return;
            }})
    );
};