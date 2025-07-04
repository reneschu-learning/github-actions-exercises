# Übung 5: Bedingungen

## Ziel
Lerne, wie du Bedingungen verwendest, um die Ausführung von Schritten zu steuern und mehrere Trigger-Typen elegant zu behandeln.

## Anleitung

1. **Füge einen Cron-Trigger hinzu**: Ergänze deinen Workflow aus Übung 4 um einen Zeitplan:
   - Füge einen Cron-Trigger hinzu, der jeden Tag um 9:00 Uhr UTC läuft
   - Behalte die bestehenden manuellen und Issue-Trigger bei

2. **Verbessere die bedingte Logik**: Optimiere den Workflow, sodass alle drei Trigger-Typen behandelt werden:
   - Manueller Trigger: Zeige eine personalisierte Begrüßung
   - Issue-Trigger: Zeige Issue-Informationen
   - Zeitplan-Trigger: Zeige eine tägliche Statusmeldung
   - Der run-name soll entweder die Issue-Nummer, `Cron` (bei Zeitplan), oder den Akteur (bei manuellem Trigger) anzeigen:
     - Issue-Trigger: `Issue #<issue_number> triggered this workflow`
     - Zeitplan-Trigger: `Cron triggered this workflow`
     - Manueller Trigger: `Alice triggered this workflow`

## Wichtige Konzepte
- Cron-Scheduling mit `schedule.cron`
- Bedingungen auf Schritt-Ebene mit `if:`
- Komplexe bedingte Ausdrücke
- Standardwerte und Null-Prüfung
- Strategien zur Behandlung mehrerer Trigger

## Erwartete Ausgabe

**Bei manuellem Trigger:**
```
Hello Alice!
Triggered by: [dein-benutzername]
Repository: [owner/repo-name]
Reference: refs/heads/main
```

**Bei Issue-Trigger:**
```
New issue opened!
Issue #5: Bug in login functionality
Body: When I try to log in with my credentials...
Opened by: user123
Issue URL: https://github.com/owner/repo/issues/5
```

**Bei Zeitplan-Trigger:**
```
Daily status check - All systems operational
Current time: 2024-01-15T09:00:00Z
```

## Erweiterte Konzepte
- Verwendung der `format()`-Funktion
- Kombinieren von Bedingungen mit `&&` und `||`
- Prüfung auf null/leer

## Hinweise
- Verwende `'0 9 * * *'` für den täglichen Cron-Trigger um 9 Uhr UTC (Zeitplan-Trigger sind **immer** UTC)
- Prüfe den Event-Typ: Vergleiche `github.event_name` mit dem gewünschten Event oder prüfe, ob `github.event.<event_type>` null ist
- `format()` hilft, dynamische run-names zu erstellen (Syntax: `format('text {0} {1}', variable0, variable1)`)
- Um das Hash-Symbol im run-name zu escapen, setze den gesamten Ausdruck in einfache Anführungszeichen und verwende doppelte einfache Anführungszeichen für String-Inhalte:
  ```yaml
  run-name: '${{ format(''Issue #{0}'', github.event.issue.number) }}'
  ```

## Lösung
Wenn du nicht weiterkommst, sieh im [solution](../../solutions/05-conditions/) Verzeichnis nach einem funktionierenden Beispiel nach.
