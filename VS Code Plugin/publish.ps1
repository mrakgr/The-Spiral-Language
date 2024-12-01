# Suppresses warnings.
$WarningPreference = 'SilentlyContinue'
# This instructs PowerShell to treat non-terminating errors as terminating errors, which will halt script execution.
$ErrorActionPreference = "Stop"

try {
    $keys = Get-Content -Raw -Path .\keys.json | ConvertFrom-Json
    function Publish-Vsce {
        param (
            [string] $Rank = "patch" # Can also be "minor"
        )
        Write-Host "Publishing on VSCE."
        npx "@vscode/vsce" publish $Rank # https://marketplace.visualstudio.com/items?itemName=mrakgr.spiral-lang-vscode
    }
    
    function Publish-Ovsx {
        Write-Host "Publishing on OVSX."
        npx ovsx publish -p $keys.ovsx # https://open-vsx.org/extension/mrakgr/spiral-lang-vscode
    }

    $files = @(
        "readme.md"
        "spiral_logo.png"
        )
    foreach ($file in $files) { # Copies the readme and the image files into the current folder so they get packed with the extension.
        Copy-Item ../$file .
    }
    
    Publish-Vsce -Rank "patch"
    Publish-Ovsx
}
finally {
    foreach ($file in $files) { # Copies the readme and the image files in the current folder
        Remove-Item ./$file
    }
}
