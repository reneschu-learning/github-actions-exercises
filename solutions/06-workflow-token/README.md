# Lösung: Verwendung des Workflow-Tokens

Dieses Verzeichnis enthält die Lösung für Übung 6: Verwendung des Workflow-Tokens.

## Dateien
- `hello-world.yml` – Die GitHub Actions Workflow-Datei mit GitHub CLI-Integration

## Wichtige Merkmale
- Verwendet `GITHUB_TOKEN` zur Authentifizierung
- GitHub CLI (`gh`) Integration für API-Interaktionen
- Abruf von Repository-Informationen
- Kommentarfunktion für Issues
- Auflistung von Workflow-Läufen
- Bedingte Ausführung je nach Trigger-Typ

## Trigger
- `workflow_dispatch` – Manueller Trigger mit Inputs
- `issues` (opened) – Trigger bei Issue-Erstellung
- `schedule` – Täglich um 9:00 Uhr UTC

## Verwendete GitHub CLI-Befehle
- `gh auth status` – Authentifizierung der GitHub CLI prüfen
- `gh repo view` – Repository-Informationen anzeigen
- `gh issue comment` – Kommentare zu Issues hinzufügen
- `gh run list` – Letzte Workflow-Läufe auflisten

## Token-Berechtigungen
Der Workflow erweitert die Standardberechtigungen des `GITHUB_TOKEN` und benötigt:
- Leserechte für Repository-Inhalte
- Schreibrechte für Issues
- Leserechte für Actions

## Erweiterte Konzepte
- Verwendung von Umgebungsvariablen mit der GitHub CLI
- Token-Authentifizierungsmuster
- Bedingte Ausführung von Schritten
- Fehlerbehandlung bei CLI-Befehlen
- Parsen von JSON-Ausgaben

## Verwendung
1. Kopiere die Workflow-Datei nach `.github/workflows/` in deinem Repository
2. Committe und pushe die Änderungen
3. Teste alle drei Trigger-Typen:
   - Manuelle Ausführung für Repository-Infos
   - Erstelle ein Issue für automatisierte Kommentare
   - Warte auf den Zeitplan für die Workflow-Historie

## Sicherheitsbest Practices
- Verwende immer das bereitgestellte `GITHUB_TOKEN` statt persönlicher Zugriffstokens, wenn möglich
- Beachte das Prinzip der minimalen Rechtevergabe
- Sei vorsichtig beim Einsatz von Tokens in öffentlichen Repositories
- Nutze den `permissions`-Schlüssel, um den Token-Umfang explizit zu erweitern oder einzuschränken, falls nötig
