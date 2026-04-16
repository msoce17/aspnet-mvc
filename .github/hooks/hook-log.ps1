param($payload)

$logPath = 'C:\Users\Mateo\source\repos\SustavZaOrganizacijuNogometnihTurnira\.github\hooks\agent_log.txt'

function Get-LogMetadata {
    param(
        [string]$RawContent,
        [string]$FallbackSource
    )

    $eventName = $null
    $content = $RawContent

    try {
        $parsed = $RawContent | ConvertFrom-Json -ErrorAction Stop

        $eventName = @(
            $parsed.hook_event_name
            $parsed.event_name
            $parsed.event
            $parsed.hook
        ) | Where-Object { $_ } | Select-Object -First 1

        $preferredContent = @(
            $parsed.prompt
            $parsed.message
            $parsed.command
            $parsed.tool_name
        ) | Where-Object { $_ } | Select-Object -First 1

        if ($preferredContent) {
            $content = [string]$preferredContent
        }
    }
    catch {
    }

    return @{
        EventName = $eventName
        Content = $content
        Source = $FallbackSource
    }
}

function Format-LogEntry {
    param(
        [string]$HeaderLabel,
        [string]$HeaderValue,
        [string]$Content
    )

    $timestamp = Get-Date -Format 'yyyy-MM-dd HH:mm:ss'
    return @(
        "[$timestamp] $HeaderLabel`: $HeaderValue"
        $Content
        ''
    )
}

if ($payload) {
    $metadata = Get-LogMetadata -RawContent ([string]$payload) -FallbackSource 'parameter'
    if ($metadata.EventName) {
        $entry = Format-LogEntry -HeaderLabel 'EVENT' -HeaderValue $metadata.EventName -Content $metadata.Content
    }
    else {
        $entry = Format-LogEntry -HeaderLabel 'SOURCE' -HeaderValue $metadata.Source -Content $metadata.Content
    }

    Add-Content -Path $logPath -Value $entry
}
elseif ($input) {
    $content = $input | Out-String
    $metadata = Get-LogMetadata -RawContent $content.TrimEnd() -FallbackSource 'pipeline'
    if ($metadata.EventName) {
        $entry = Format-LogEntry -HeaderLabel 'EVENT' -HeaderValue $metadata.EventName -Content $metadata.Content
    }
    else {
        $entry = Format-LogEntry -HeaderLabel 'SOURCE' -HeaderValue $metadata.Source -Content $metadata.Content
    }

    Add-Content -Path $logPath -Value $entry
}
