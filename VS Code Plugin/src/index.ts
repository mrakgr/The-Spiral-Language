import * as path from "path";
import { window, ExtensionContext, languages, workspace, DiagnosticCollection, TextDocument, Diagnostic, DiagnosticSeverity, tasks, RelativePattern, Position, Range } from "vscode";
import * as zmq from "zeromq";

type Result<a,b> = {Case:"Ok", ResultValue:a} | {Case:"Error", ErrorValue:b}
type ConfigResumableError =
    {Case:"DuplicateFiles",Item:{Item1: string,Item2:any []) []}
//     | DuplicateRecordFields of (string * Pos []) []
//     | MissingNecessaryRecordFields of string [] * Range
//     | DirectoryInvalid of string * Pos
//     | MainMustBeLast of Pos
//     | MainMustBeAFile of Pos
// type ConfigFatalError =
//     | Tabs of Pos []
//     | ConfigCannotReadProjectFile of string
//     | ConfigProjectDirectoryPathInvalid of string
//     | ParserError of string * Pos
//     | UnexpectedException of string

const uri = "tcp://localhost:13805";

const client = async (Item : string) => {
    const sock = new zmq.Request();
    sock.connect(uri);
    await sock.send(JSON.stringify({Case:"ProjectDir", Item}));
    const [msg] = await sock.receive();
    window.showInformationMessage(msg.toString());
};

export const activate = async (ctx : ExtensionContext) => {
    window.showInformationMessage("Spiral plugin is active.");

    const config_errors = languages.createDiagnosticCollection();
    ctx.subscriptions.push(
        config_errors,
        workspace.onDidChangeTextDocument(async x => {
            if (path.extname(x.document.uri.path) === ".spiproj"){
                const doc = x.document;
                const project_path = path.dirname(doc.uri.fsPath);
                window.showInformationMessage(project_path);
                await client(project_path);
                // const diag = new Diagnostic(range,"random error",DiagnosticSeverity.Error);
                // config_errors.set(doc.uri,[diag])
                }
        })
    );
};