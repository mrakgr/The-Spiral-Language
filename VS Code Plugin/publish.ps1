$keys = Get-Content -Raw -Path .\keys.json | ConvertFrom-Json
$files = @(
    "readme.md"
    "spiral_logo.png"
)
foreach ($file in $files) { # Copies the readme and the image files into the current folder so they get packed with the extension.
    Copy-Item ../$file .
}
# vsce publish minor
# vsce publish patch # https://marketplace.visualstudio.com/items?itemName=mrakgr.spiral-lang-vscode
npx ovsx publish -p $keys.ovsx # https://open-vsx.org/extension/mrakgr/spiral-lang-vscode
foreach ($file in $files) { # Copies the readme and the image files in the current folder
    Remove-Item ./$file
}