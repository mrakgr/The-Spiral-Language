import * as path from "path"
import * as fs from "fs"

const testFolder = 'C:/Users/Marko/Source/Repos/The Spiral Language/VS Code Plugin';

const readDir = (dir: string, indent: number) => {
    console.log(" ".repeat(indent) + dir);
    try {
        const files = fs.readdirSync(dir)
        files.forEach(async file => { readDir(path.join(dir,file), indent + 4) });
    } catch (e) {}
    // fs.readdir(dir, (err, files) => {
    //     if (files) {
    //         files.forEach(async file => { readDir(file,indent+4) });
    //     }
    // });
}
readDir(testFolder, 0)