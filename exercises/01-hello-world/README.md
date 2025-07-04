# Übung 1: Hallo Welt

## Ziel
Erstelle einen einfachen GitHub Actions Workflow, der „Hello, World!“ in der Konsole ausgibt, wenn er manuell ausgelöst wird.

## Anleitung

1. **Erstelle eine Workflow-Datei**: Lege in deinem Repository eine neue Datei unter `.github/workflows/hello-world.yml` an.

2. **Definiere den Workflow**: Erstelle einen Workflow mit folgenden Anforderungen:
   - Name: „Hello World“
   - Auslöser: Manueller Auslöser mit `workflow_dispatch`
   - Job: Ein einzelner Job namens „hello“, der auf `ubuntu-latest` läuft
   - Schritt: Ein einzelner Schritt, der „Hello, World!“ in die Konsole ausgibt

3. **Teste den Workflow**: Committe und pushe deine Änderungen und löse dann den Workflow manuell im GitHub Actions Tab aus.

## Wichtige Konzepte
- Grundstruktur eines GitHub Actions Workflows
- Manuelle Workflow-Auslöser (`workflow_dispatch`)
- Jobs und Schritte
- Verwendung des `echo`-Befehls in Workflow-Schritten

## Erwartete Ausgabe
Wenn du den Workflow ausführst, solltest du „Hello, World!“ in den Workflow-Logs sehen.

## Hinweise
- Verwende das Schlüsselwort `run`, um Shell-Befehle auszuführen
- Die Grundstruktur eines Workflows umfasst `name`, `on`, `jobs` und innerhalb der Jobs: `runs-on` und `steps`
- Jeder Schritt kann einen `name` und entweder `run` oder `uses` haben

## Lösung
Wenn du nicht weiterkommst, sieh im [solution](../../solutions/01-hello-world/) Verzeichnis nach einem funktionierenden Beispiel nach.
