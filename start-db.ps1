$ErrorActionPreference = "Stop"
$composeFile = "$PSScriptRoot\docker-compose.yml"
$envFile = Join-Path $PSScriptRoot ".env"

Write-Host "Resetting previous Docker SQL container and volume..."
docker-compose -f $composeFile down -v

Write-Host "Starting SQL Server container..."
docker-compose -f $composeFile up -d

Write-Host "Waiting for SQL Server container to be marked healthy..."

$maxAttempts = 20
$attempt = 0
$healthy = $false

do {
    Start-Sleep -Seconds 2
    $status = docker inspect -f '{{.State.Health.Status}}' HowToWpfResearch_Database 2>&1
    Write-Host "Attempt $($attempt + 1): Status = $status"
    $healthy = $status -eq "healthy"
    $attempt++
} while (-not $healthy -and $attempt -lt $maxAttempts)

if (-not $healthy) {
    Write-Warning "Container never became healthy. Proceeding anyway..."
    docker logs HowToWpfResearch_Database --tail 20
}

Write-Host "Loading environment variables from $envFile"

if (Test-Path $envFile) {
    Get-Content $envFile | ForEach-Object {
        if ($_ -match '^(?<key>[^=]+)=(?<val>.+)$') {
            [System.Environment]::SetEnvironmentVariable($matches['key'], $matches['val'])
        }
    }
    Write-Host "Environment variables loaded into process."
} else {
    Write-Warning ".env file not found!"
}

Write-Host "Proceeding to apply EF Core migrations..."

try {
    Start-Sleep -Seconds 2
    dotnet ef database update `
        --project "Data\Data.csproj" `
        --startup-project "DbMigrator\DbMigrator.csproj"

    Write-Host "Migrations applied. Database is ready."
} catch {
    Write-Error "EF Core migration failed. Check your DB setup or EF code."
    throw
}
