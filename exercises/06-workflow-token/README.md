# Übung 6: Verwendung des Workflow-Tokens

## Ziel
Lerne, wie du das automatisch generierte Workflow-Token (`GITHUB_TOKEN`) verwendest, um API-Anfragen zu authentifizieren und mit deinem Repository über die GitHub CLI zu interagieren.

## Anleitung

1. **Verwende die GitHub CLI**: Erweitere deinen Workflow aus Übung 5 um Schritte, die die GitHub CLI (`gh`) nutzen:
   - Füge einen Schritt hinzu, der einen Kommentar zu einem Issue erstellt, wenn der Workflow durch ein Issue-Event ausgelöst wird
   - Füge einen Schritt hinzu, der Repository-Informationen abruft, wenn der Workflow manuell ausgelöst wird
   - Füge einen Schritt hinzu, der die letzten Workflow-Läufe auflistet, wenn der Workflow durch den Zeitplan ausgelöst wird

2. **Token-Authentifizierung**: Lerne, das `GITHUB_TOKEN` zu verwenden:
   - Nutze das Token, um GitHub CLI-Befehle zu authentifizieren
   - Verstehe die Standardberechtigungen des Workflow-Tokens
   - Übe das Lesen von Repository-Daten und das Schreiben von Kommentaren

3. **Sicherheitsaspekte**:
   - Verstehe, welche Berechtigungen das Workflow-Token standardmäßig hat
   - Lerne, wann und warum du zusätzliche Berechtigungen anfordern solltest

## Wichtige Konzepte
- `GITHUB_TOKEN` Secret und dessen automatische Erstellung
- GitHub CLI (`gh`) Tool und Integration in Workflows
- Token-Berechtigungen und Sicherheitsgrenzen
- API-Authentifizierung in Workflows
- Bedingte Ausführung je nach Trigger-Typ

## Erwartete Ausgabe

**Bei manuellem Trigger:**
```
Hello Alice!
Triggered by: [dein-benutzername]
Repository: [owner/repo-name]
Reference: refs/heads/main

Repository Information:
Name: my-repo
Owner: my-username
Description: A sample repository
Private: false
Default branch: main
```

**Bei Issue-Trigger:**
```
New issue opened!
Issue #5: Bug in login functionality
Body: When I try to log in with my credentials...
Opened by: user123
Issue URL: https://github.com/owner/repo/issues/5

✓ Kommentar zu Issue #5 hinzugefügt
```

**Bei Zeitplan-Trigger:**
```
Daily status check - All systems operational
Current time: 2024-01-15T09:00:00Z

Letzte Workflow-Läufe:
✓ Hello World with Conditions - main (completed)
✓ Hello World with Conditions - main (completed)
⏳ Hello World with Conditions - main (in_progress)
```

## GitHub CLI-Befehle, die verwendet werden
- `gh repo view` – Repository-Informationen abrufen
- `gh issue comment` – Kommentar zu einem Issue hinzufügen
- `gh run list` – Workflow-Läufe auflisten

## Sicherheitshinweise
- Das `GITHUB_TOKEN` ist in allen Workflow-Läufen automatisch verfügbar
- Es hat standardmäßig Leserechte für Repository-Inhalte und Pakete
- Es kann nicht auf andere Repositories zugreifen oder Admin-Aktionen ausführen
- Die Token-Berechtigungen können mit dem `permissions`-Schlüssel im Workflow erweitert werden

## Hinweise
- Die GitHub CLI ist auf GitHub-gehosteten Runnern vorinstalliert
- Mit `gh auth status` kannst du die Authentifizierung prüfen
- Umgebungsvariablen können an `gh`-Befehle übergeben werden
- Das Token ist verfügbar als `${{ secrets.GITHUB_TOKEN }}`
- Verwende bedingte Schritte basierend auf `github.event_name`, um zu steuern, wann welcher Schritt ausgeführt wird
