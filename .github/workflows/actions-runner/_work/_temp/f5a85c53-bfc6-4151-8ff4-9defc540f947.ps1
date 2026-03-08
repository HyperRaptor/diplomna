$ErrorActionPreference = 'stop'
$unityPath = "F:\Unity\Installs\6000.3.8f1\Editor\Unity.exe"
$projectPath = (Get-Location).Path
$logFile = Join-Path $projectPath "artifacts\unity-log.txt"
$testResults = Join-Path $projectPath "artifacts\test-results.xml"
$coveragePath = Join-Path $projectPath "CodeCoverage"
$arguments = @(
  "-batchmode",
  "-nographics",
  "-projectPath", $projectPath,
  "-runTests",
  "-testMode", "EditMode",
  "-testResults", $testResults,
  "-enableCodeCoverage",
  "-coverageResultsPath", $coveragePath,
  "-coverageOptions", "generateAdditionalMetrics;generateHtmlReport;generateBadgeReport",
  "-debugCodeOptimization",
  "-logFile", $logFile
)
$process = Start-Process -FilePath $unityPath -ArgumentList $arguments -Wait -PassThru
$exitCode = $process.ExitCode
Write-Host "Unity exited with code: $exitCode"
if (Test-Path $logFile) {
  Get-Content $logFile | Where-Object {
    $_ -match "error|warning|Test|Coverage|FAILED|PASSED|Exception|seqpnt|sequence"
  }
}
exit $exitCode

if ((Test-Path -LiteralPath variable:\LASTEXITCODE)) { exit $LASTEXITCODE }