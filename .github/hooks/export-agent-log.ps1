param(
    [string]$SessionFile,
    [string]$OutputPath = 'C:\Users\Mateo\source\repos\SustavZaOrganizacijuNogometnihTurnira\.github\hooks\agent_log.txt'
)

$codexHome = Join-Path $env:USERPROFILE '.codex'
$sessionIndexPath = Join-Path $codexHome 'session_index.jsonl'
$sessionRoot = Join-Path $codexHome 'sessions'

function Get-LatestSessionFile {
    if (-not (Test-Path -LiteralPath $sessionIndexPath)) {
        throw "Could not find session index at $sessionIndexPath"
    }

    $latestSession = Get-Content -LiteralPath $sessionIndexPath |
        Where-Object { $_.Trim() } |
        ForEach-Object { $_ | ConvertFrom-Json } |
        Sort-Object updated_at -Descending |
        Select-Object -First 1

    if (-not $latestSession) {
        throw 'No Codex sessions were found in the session index.'
    }

    $matchingFile = Get-ChildItem -LiteralPath $sessionRoot -Recurse -Filter "*$($latestSession.id).jsonl" |
        Select-Object -First 1

    if (-not $matchingFile) {
        throw "Could not find a session file for session id $($latestSession.id)"
    }

    return $matchingFile.FullName
}

function Get-TextContent {
    param($ContentItems)

    if (-not $ContentItems) {
        return $null
    }

    $texts = foreach ($item in $ContentItems) {
        if ($item.type -in @('input_text', 'output_text')) {
            $item.text
        }
    }

    $joined = ($texts | Where-Object { $_ }) -join [Environment]::NewLine
    if ($joined) {
        return $joined.Trim()
    }

    return $null
}

function Normalize-MessageBody {
    param(
        [string]$Body,
        [string]$Label
    )

    if (-not $Body) {
        return $null
    }

    $trimmed = $Body.Trim()

    if ($trimmed -match '^<environment_context>[\s\S]*</environment_context>$') {
        return $null
    }

    if ($trimmed -match '^<turn_aborted>[\s\S]*</turn_aborted>$') {
        return $null
    }

    return $trimmed
}

function Get-AssistantLabel {
    return 'ASSISTANT'
}

function Get-CommandSummary {
    param($Payload)

    $commandText = if ($Payload.command) {
        ($Payload.command -join ' ')
    }
    elseif ($Payload.parsed_cmd) {
        ($Payload.parsed_cmd | ForEach-Object { $_.cmd }) -join [Environment]::NewLine
    }
    else {
        $null
    }

    if (-not $commandText) {
        return $null
    }

    if ($commandText -match ' -Command (.+)$') {
        return $matches[1].Trim()
    }

    return $commandText.Trim()
}

function Should-IncludeToolEntry {
    param(
        [string]$CommandSummary,
        [int]$ExitCode
    )

    if ($ExitCode -ne 0) {
        return $true
    }

    if (-not $CommandSummary) {
        return $false
    }

    $readOnlyPatterns = @(
        '^Get-Content\b'
        '^Get-ChildItem\b'
        '^rg\b'
    )

    foreach ($pattern in $readOnlyPatterns) {
        if ($CommandSummary -match $pattern) {
            return $false
        }
    }

    return $true
}

function Format-Entry {
    param(
        [object]$Timestamp,
        [string]$Label,
        [string]$Body
    )

    $normalizedBody = Normalize-MessageBody -Body $Body -Label $Label

    if (-not $normalizedBody) {
        return $null
    }

    $timestampText = $Timestamp
    if ($Timestamp -is [datetime]) {
        $timestampText = $Timestamp.ToString('yyyy-MM-dd HH:mm:ss')
    }

    return @(
        "[$timestampText] $Label"
        $normalizedBody
        ''
    ) -join [Environment]::NewLine
}

if (-not $SessionFile) {
    $SessionFile = Get-LatestSessionFile
}

$entries = New-Object System.Collections.Generic.List[string]

foreach ($line in Get-Content -LiteralPath $SessionFile) {
    if (-not $line.Trim()) {
        continue
    }

    $record = $line | ConvertFrom-Json

    switch ($record.type) {
        'event_msg' {
            switch ($record.payload.type) {
                'user_message' {
                    $entry = Format-Entry -Timestamp $record.timestamp -Label 'USER' -Body $record.payload.message
                    if ($entry) { [void]$entries.Add($entry) }
                }
                'agent_message' {
                    $entry = Format-Entry -Timestamp $record.timestamp -Label (Get-AssistantLabel) -Body $record.payload.message
                    if ($entry) { [void]$entries.Add($entry) }
                }
                'exec_command_end' {
                    $commandSummary = Get-CommandSummary -Payload $record.payload
                    $exitCode = if ($null -ne $record.payload.exit_code) { [int]$record.payload.exit_code } else { 0 }

                    if (Should-IncludeToolEntry -CommandSummary $commandSummary -ExitCode $exitCode) {
                        $bodyLines = @()
                        if ($commandSummary) {
                            $bodyLines += "Command: $commandSummary"
                        }
                        if ($exitCode -ne 0) {
                            $bodyLines += "Exit Code: $exitCode"
                        }
                        elseif ($commandSummary -match '^Invoke-Pester\b|^dotnet test\b') {
                            $bodyLines += 'Result: completed successfully'
                        }

                        $entry = Format-Entry -Timestamp $record.timestamp -Label 'TOOL' -Body ($bodyLines -join [Environment]::NewLine)
                        if ($entry) { [void]$entries.Add($entry) }
                    }
                }
            }
        }
        'response_item' {
            if ($record.payload.type -eq 'message' -and $record.payload.role -eq 'user') {
                $body = Get-TextContent -ContentItems $record.payload.content
                $entry = Format-Entry -Timestamp $record.timestamp -Label 'USER' -Body $body
                if ($entry) { [void]$entries.Add($entry) }
            }
            elseif ($record.payload.type -eq 'message' -and $record.payload.role -eq 'assistant') {
                $body = Get-TextContent -ContentItems $record.payload.content
                $entry = Format-Entry -Timestamp $record.timestamp -Label (Get-AssistantLabel) -Body $body
                if ($entry) { [void]$entries.Add($entry) }
            }
        }
    }
}

$uniqueEntries = $entries | Select-Object -Unique
Set-Content -LiteralPath $OutputPath -Value $uniqueEntries

Write-Output "Exported agent log to $OutputPath from $SessionFile"
