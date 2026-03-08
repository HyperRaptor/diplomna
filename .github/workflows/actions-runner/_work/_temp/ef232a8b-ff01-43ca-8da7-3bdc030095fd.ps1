$ErrorActionPreference = 'stop'
New-Item -ItemType Directory -Force -Path artifacts, CodeCoverage
if ((Test-Path -LiteralPath variable:\LASTEXITCODE)) { exit $LASTEXITCODE }