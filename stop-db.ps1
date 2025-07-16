$ErrorActionPreference = "Stop"
$composeFile = "$PSScriptRoot\docker-compose.yml"

Write-Host "Stopping and removing SQL Server container and volume..."
docker-compose -f $composeFile down -v
Write-Host "SQL Server fully cleaned up."
