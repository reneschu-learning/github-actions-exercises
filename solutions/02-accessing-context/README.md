# Lösung: Zugriff auf Kontext

Dieses Verzeichnis enthält die Lösung für Übung 2: Zugriff auf Kontext.

## Dateien
- `hello-world.yml` – Die GitHub Actions Workflow-Datei mit Kontextzugriff

## Wichtige Merkmale
- Manueller Auslöser mit `workflow_dispatch`
- Zugriff auf GitHub-Kontextinformationen
- Zeigt Akteur, Repository und Referenzinformationen an
- Verwendet mehrzeilige run-Befehle

## Verwendete Kontextvariablen
- `github.actor` – Benutzername, der den Workflow ausgelöst hat
- `github.repository` – Repository-Name im owner/repo-Format
- `github.ref` – Git-Referenz (Branch/Tag)

## Verwendung
1. Kopiere die Workflow-Datei nach `.github/workflows/` in deinem Repository
2. Committe und pushe die Änderungen
3. Löse den Workflow manuell aus
4. Beobachte die Kontextinformationen in den Logs

## Was du lernst
- GitHub Kontextobjekt
- Zugriff auf Kontextvariablen mit `${{ }}`
- Mehrzeilige Shell-Befehle mit `|`
- Häufige Kontext-Properties
