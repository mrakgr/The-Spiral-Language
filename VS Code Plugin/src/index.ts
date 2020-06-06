import * as path from "path";
import { window, ExtensionContext, languages, workspace, DiagnosticCollection, TextDocument, Diagnostic, DiagnosticSeverity, tasks, RelativePattern, Position, Range } from "vscode";
import * as zmq from "zeromq";

const uri = "tcp://localhost:13805";

const client = async (text : string) => {
    const sock = new zmq.Request();
    sock.connect(uri);
    await sock.send(text);
    const [msg] = await sock.receive();
    const {line, lineStart, lineEnd} = JSON.parse(msg.toString());
    return new Range(line,lineStart,line,lineEnd);
};

export const activate = async (ctx : ExtensionContext) => {
    window.showInformationMessage("Spiral plugin is active.");

    const config_errors = languages.createDiagnosticCollection();
    ctx.subscriptions.push(
        config_errors,
        workspace.onDidChangeTextDocument(async x => {
            if (path.extname(x.document.uri.path) === ".spiproj"){
                const doc = x.document;
                const range = await client(doc.getText());
                const diag = new Diagnostic(range,"random error",DiagnosticSeverity.Error);
                config_errors.set(doc.uri,[diag])
                }
        })
    );
};