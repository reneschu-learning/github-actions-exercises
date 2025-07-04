# Übung 4: Issue-Trigger

## Ziel
Lerne, wie du Workflows basierend auf GitHub-Issues auslöst und verstehe die Sicherheitsaspekte beim Umgang mit Kontext und Eingaben.

## Anleitung

1. **Füge einen Issue-Trigger hinzu**: Erweitere deinen Workflow aus Übung 3, sodass er auch ausgelöst wird, wenn:
   - Ein Issue im Repository geöffnet wird
   - Der manuelle Trigger mit Inputs aus Übung 3 bleibt erhalten
     - Das `name`-Input ist jetzt optional und hat den Standardwert „World“
   - Der Titel des Issues ausgegeben wird
   - Der Body des Issues ausgegeben wird
   - Die Issue-Nummer und URL ausgegeben werden
   - Angezeigt wird, wer das Issue geöffnet hat

2. **Erstelle ein neues Issue**: Nachdem du den Workflow angepasst hast, erstelle ein neues Issue im Repository, um den Issue-Trigger zu testen.

## Wichtige Konzepte
- Mehrere Trigger-Typen in einem Workflow
- Issue-Events und deren Typen (`opened`, `closed`, `edited`, usw.)
- Issue-Kontext: `github.event.issue`
- Sicherheitsaspekte beim Umgang mit Issue-Inhalten

## Erwartete Ausgabe

**Wenn durch ein Issue ausgelöst:**
```
 !
Triggered by: [dein-benutzername]
Repository: [owner/repo-name]
Reference: refs/heads/main

New issue opened!
Issue #5: Bug in login functionality
Body: When I try to log in with my credentials...
Opened by: user123
Issue URL: https://github.com/owner/repo/issues/5
```

**Wenn manuell ausgelöst (greeting=Welcome, name=Alice):**
```
Welcome Alice!
Triggered by: [dein-benutzername]
Repository: [owner/repo-name]
Reference: refs/heads/main

New issue opened!
Issue #:
Body:
Opened by:
Issue URL:
```

Wie du siehst, fehlt je nach auslösendem Event entweder die Issue-Information oder die Begrüßung. Wir beheben das im nächsten Schritt.

## Sicherheitshinweis
- Issue-Titel und -Bodies können bösartigen Inhalt enthalten
- Sei vorsichtig beim Verwenden von Issue-Inhalten in Skripten
- Ziehe in Betracht, Issue-Inhalte zu bereinigen oder deren Verwendung einzuschränken
- Vermeide es, Issue-Inhalte direkt als Code auszuführen

## Hinweise
- Verwende mehrere Trigger: `on: [workflow_dispatch, issues]`
- Gib die Issue-Typen an: `on.issues.types: [opened]`
- Greife auf Issue-Daten zu: `github.event.issue.title`, `github.event.issue.body` usw.
- Verwende Umgebungsvariablen oder andere Methoden zur Bereinigung bei potenziell unsicheren Inhalten

## Lösung
Wenn du nicht weiterkommst, sieh im [solution](../../solutions/04-issue-trigger/) Verzeichnis nach einem funktionierenden Beispiel nach.
