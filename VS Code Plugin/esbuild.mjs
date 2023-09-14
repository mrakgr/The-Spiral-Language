import * as esbuild from 'esbuild'

let result = await esbuild.build({
  entryPoints: ['src/index.ts'],
  bundle: true,
  outdir: 'out',
  platform: 'node',
  external: ['vscode']
})
console.log(result)