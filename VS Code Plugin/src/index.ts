import * as path from "path";
import { window, ExtensionContext, languages, workspace, DiagnosticCollection, TextDocument, Diagnostic, DiagnosticSeverity, tasks, RelativePattern } from "vscode";

function randomInt(max : number) {
  return Math.floor(Math.random() * Math.floor(max));
}

const errorOnRandomLine = (d : DiagnosticCollection, doc : TextDocument) => {
    const line = doc.lineAt(randomInt(doc.lineCount));
    const diag = new Diagnostic(line.range,"random error",DiagnosticSeverity.Error);
    d.set(doc.uri,[diag])
};

export const activate = async (ctx : ExtensionContext) => {
    window.showInformationMessage("Spiral plugin is active.");
    const folders = workspace.workspaceFolders;
    if (!folders) return;
    const projFiles = await Promise.all(folders.map(x => workspace.findFiles(new RelativePattern(x,"*.spiproj"))));
    const projFilesSet = new Set(projFiles.flat().map(x => x.toString()));

    const config_errors = languages.createDiagnosticCollection();
    ctx.subscriptions.push(
        config_errors,
        workspace.onDidChangeTextDocument(x => {
            if (path.extname(x.document.uri.path) === ".spiproj")
                errorOnRandomLine(config_errors, x.document);
        })
    );
};