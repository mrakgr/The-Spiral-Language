$keys = Get-Content -Raw -Path .\keys.json | ConvertFrom-Json
$files = @(
    "readme.md"
    "spiral_logo.png"
)
foreach ($file in $files) {
    Copy-Item ../$file .
}
# vsce publish minor
vsce publish patch
npx ovsx publish -p $keys.ovsx
foreach ($file in $files) {
    Remove-Item ./$file
}