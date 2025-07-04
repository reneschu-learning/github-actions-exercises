# Lösung: Issue-Trigger

Dieses Verzeichnis enthält die Lösung für Übung 4: Issue-Trigger.

## Dateien
- `hello-world.yml` – Die GitHub Actions Workflow-Datei mit mehreren Triggern

## Wichtige Merkmale
- Mehrere Trigger-Typen (manuell und Issues)
- Zugriff auf Issue-Kontext
- Sichere Verarbeitung von Kontext- und Eingabedaten

## Trigger
- `workflow_dispatch` – Manueller Trigger mit Inputs
- `issues` (opened) – Automatischer Trigger, wenn Issues geöffnet werden

## Sicherheitshinweis
- Kontext- und Eingabedaten sollten als nicht vertrauenswürdig behandelt werden (potenziell bösartiger Inhalt und Skript-Injektion möglich)
- Verwende Umgebungsvariablen, um Kontext- und Eingabedaten sicher zu verarbeiten
- Vermeide es, Issue-Inhalte direkt als Code auszuführen

## Verwendung
1. Kopiere die Workflow-Datei nach `.github/workflows/` in deinem Repository
2. Committe und pushe die Änderungen
3. Teste beide Trigger-Methoden:
   - Erstelle ein neues Issue, um den automatischen Trigger zu testen

## Was du lernst
- Konfiguration mehrerer Trigger
- Verarbeitung von Issue-Events
- Sicherheitsbest Practices
