$ErrorActionPreference = 'stop'
$cacheDir = "F:\UnityPackageCache"
New-Item -ItemType Directory -Force -Path $cacheDir
$bootConfig = "ProjectSettings\boot.config"
if (Test-Path $bootConfig) {
  $content = Get-Content $bootConfig
  $content | Where-Object { $_ -notmatch "packagecache-path" } | Set-Content $bootConfig
}
Add-Content -Path $bootConfig -Value "packagecache-path=$cacheDir"

if ((Test-Path -LiteralPath variable:\LASTEXITCODE)) { exit $LASTEXITCODE }