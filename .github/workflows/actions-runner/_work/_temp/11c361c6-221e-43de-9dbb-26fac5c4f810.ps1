$ErrorActionPreference = 'stop'
if (Test-Path "Library") {
  Remove-Item -Recurse -Force "Library"
}

if ((Test-Path -LiteralPath variable:\LASTEXITCODE)) { exit $LASTEXITCODE }