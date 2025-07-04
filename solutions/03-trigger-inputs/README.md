# Lösung: Trigger-Inputs

Dieses Verzeichnis enthält die Lösung für Übung 3: Trigger-Inputs.

## Dateien
- `hello-world.yml` – Die GitHub Actions Workflow-Datei mit Input-Verarbeitung

## Wichtige Merkmale
- Manueller Auslöser mit benutzerdefinierten Inputs
- Erforderliche und optionale Eingabeparameter
- Standardwerte für optionale Inputs
- Personalisierte Begrüßung mit den Inputs
- Anzeige der Kontextinformationen

## Eingabeparameter
- `name` (erforderlich) – Name des Benutzers für die personalisierte Begrüßung
- `greeting` (optional) – Benutzerdefinierte Begrüßungsnachricht, Standard ist „Hello“

## Verwendung
1. Kopiere die Workflow-Datei nach `.github/workflows/` in deinem Repository
2. Committe und pushe die Änderungen
3. Gehe zum Actions-Tab und führe den Workflow aus
4. Fülle die Eingabefelder aus, wenn du dazu aufgefordert wirst
5. Probiere verschiedene Kombinationen von Eingaben aus

## Was du lernst
- Definition von Workflow-Inputs
- Erforderliche vs. optionale Inputs
- Standardwerte
- Zugriff auf Inputs über `github.event.inputs`
- Input-Typen und Validierung
