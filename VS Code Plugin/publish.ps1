param (
    [string]$Rank = "patch", # Can also be "minor" and "major"
    [switch]$Prerelease
)

$WarningPreference = 'SilentlyContinue'; $ErrorActionPreference = "Stop"; Set-StrictMode -Version Latest

Write-Host $Rank, $Prerelease

$prerelease_arg = if ($Prerelease) { "--pre-release" } else { $null }

$files = @(
    "readme.md"
    "spiral_logo.png"
    )

function Publish-Vsce {
    Write-Host "Publishing on VSCE."
    npx "@vscode/vsce" publish $Rank $prerelease_arg # https://marketplace.visualstudio.com/items?itemName=mrakgr.spiral-lang-vscode
}

function Publish-Ovsx {
    Write-Host "Publishing on OVSX."
    $keys = Get-Content -Raw -Path .\keys.json | ConvertFrom-Json
    npx ovsx publish -p $keys.ovsx $prerelease_arg # https://open-vsx.org/extension/mrakgr/spiral-lang-vscode
}

foreach ($file in $files) { # Copies the readme and the image files into the current folder so they get packed with the extension.
    Copy-Item ../$file .
}

Publish-Vsce
# Publish-Ovsx

foreach ($file in $files) { # Removes the copied files.
    Remove-Item ./$file
}
