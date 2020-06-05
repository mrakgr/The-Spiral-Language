import { window, ExtensionContext } from "vscode";

export const activate = (ctx : ExtensionContext) => {
    window.showInformationMessage("Spiral plugin is active.");
};