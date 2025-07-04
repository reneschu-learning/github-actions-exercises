# Lösung: Bedingungen

Dieses Verzeichnis enthält die Lösung für Übung 5: Bedingungen.

## Dateien
- `hello-world.yml` – Die GitHub Actions Workflow-Datei mit erweiterten Bedingungen

## Wichtige Merkmale
- Drei Trigger-Typen: manuell, Issues und Zeitplan
- Bedingte Ausführung auf Schritt-Ebene
- Komplexe bedingte Ausdrücke für run-names
- Sichere Verarbeitung von Kontext- und Eingabedaten

## Trigger
- `workflow_dispatch` – Manueller Trigger mit Inputs
- `issues` (opened) – Trigger bei Issue-Erstellung
- `schedule` – Täglich um 9:00 Uhr UTC

## Erweiterte Konzepte
- Bedingungen auf Schritt-Ebene mit `if:`
- Erkennung des Event-Typs
- `format()`-Funktion für dynamische run-names

## Verwendung
1. Kopiere die Workflow-Datei nach `.github/workflows/` in deinem Repository
2. Committe und pushe die Änderungen
3. Teste alle drei Trigger-Typen:
   - Manuelle Ausführung
   - Erstelle ein Issue
   - Warte auf den Zeitplan (oder passe den Cron zum Testen an)

## Was du lernst
- Komplexe bedingte Logik
- Bedingungen auf Schritt-Ebene
- Cron-Scheduling-Syntax
- Event-Typ-Erkennung
