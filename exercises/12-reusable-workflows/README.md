# Übung 12: Wiederverwendbare Workflows

## Ziel
In dieser Übung lernst du, wie du wiederverwendbare Workflows erstellst, die von anderen Workflows aufgerufen werden können. Du refaktorierst die CI/CD-Pipeline aus Übung 9, um Duplikate zu vermeiden, indem du die Deployment-Jobs in wiederverwendbare Workflows auslagerst.

## Hintergrund
Wiederverwendbare Workflows helfen, Duplikate zu vermeiden und machen deine Workflows wartbarer. Statt ähnliche Job-Definitionen zu kopieren, definierst du einen Workflow einmal und rufst ihn an mehreren Stellen mit unterschiedlichen Eingaben auf.

Vorteile wiederverwendbarer Workflows:
- **Weniger Duplikate**: Einmal schreiben, mehrfach nutzen
- **Leichtere Wartung**: Änderungen an einer Stelle
- **Konsistenz**: Alle Workflows nutzen denselben Deployment-Prozess
- **Bessere Organisation**: Trennung der Verantwortlichkeiten

## Was du lernst
- Wie man wiederverwendbare Workflows mit Inputs und Outputs erstellt
- Wie man wiederverwendbare Workflows aus anderen Workflows aufruft
- Wie man Daten zwischen aufrufendem und wiederverwendbarem Workflow übergibt
- Best Practices für die Organisation wiederverwendbarer Workflows

## Anleitung

### Schritt 1: Wiederverwendbaren Deployment-Workflow erstellen
Lege eine neue Workflow-Datei unter `.github/workflows/reusable-deploy.yml` an. Dieser Workflow soll:

1. Folgende Inputs akzeptieren:
   - `environment`: Ziel-Environment (development/production)
   - `package-name`: Name des zu deployenden Artefakts
   - `app-url`: URL, unter der die Anwendung bereitgestellt wird

2. Folgende Outputs bereitstellen:
   - `deployment-status`: Ob das Deployment erfolgreich war

3. Die Deployment-Logik aus dem ursprünglichen Workflow extrahieren (Paket herunterladen, deployen, Zusammenfassung erstellen). Achte auf Besonderheiten für Production-Deployments (z.B. Anwendung starten, Release-Tag erstellen).

### Schritt 2: Haupt-Workflow anpassen
Passe deinen Haupt-CI/CD-Workflow an:

1. Behalte die Jobs `build` und `package` bei
2. Ersetze den `deploy-dev`-Job durch einen Aufruf des wiederverwendbaren Deployment-Workflows
3. Ersetze den `deploy-prod`-Job durch einen Aufruf des wiederverwendbaren Deployment-Workflows
4. Aktualisiere den `notify`-Job, sodass er die Outputs der wiederverwendbaren Workflows nutzt
5. Stelle sicher, dass die Job-Abhängigkeiten korrekt sind

### Schritt 3: Workflow testen
1. Committe und pushe deine Änderungen, um den Workflow auszulösen
2. Teste den manuellen Aufruf mit verschiedenen Environment-Auswahlen
3. Überprüfe, ob die wiederverwendbaren Workflows korrekt aufgerufen werden
4. Prüfe, ob Artefakte korrekt zwischen Workflows übergeben werden

## Wichtige Konzepte

### Definition eines wiederverwendbaren Workflows
```yaml
name: Reusable Deployment

on:
  workflow_call:
    inputs:
      environment:
        required: true
        type: string
        description: 'Ziel-Environment'
    outputs:
      deployment-status:
        description: 'Deployment-Status'
        value: ${{ jobs.deploy.outputs.status }}
```

### Aufruf eines wiederverwendbaren Workflows
```yaml
jobs:
  deploy:
    uses: ./.github/workflows/reusable-deploy.yml
    with:
      environment: 'development'
      package-name: 'deployment-package'
    secrets: inherit
```

### Input-Typen
Wiederverwendbare Workflows unterstützen verschiedene Input-Typen:
- `string`: Textwerte
- `number`: Zahlenwerte
- `boolean`: Wahr/Falsch
- `choice`: Vorgegebene Optionen

### Secrets und Berechtigungen
- Mit `secrets: inherit` werden alle Secrets an den wiederverwendbaren Workflow übergeben
- Oder explizit einzelne Secrets mit dem `secrets`-Key
- Berechtigungen werden standardmäßig vererbt, können aber überschrieben werden

**Hinweis:** Für diese Übung sind keine Secrets zwingend nötig. Sie werden nur verwendet, um zu zeigen, wie man Secrets an wiederverwendbare Workflows übergibt.

## Erwartete Dateien
Nach Abschluss dieser Übung solltest du haben:
- `.github/workflows/reusable-deploy.yml` – Wiederverwendbarer Deployment-Workflow
- `.github/workflows/ci-cd-pipeline.yml` – Haupt-Workflow, der die wiederverwendbaren Workflows aufruft

## Tipps
- Halte die Schnittstellen (Inputs/Outputs) klar und dokumentiert
- Teste die Workflows mit verschiedenen Parametern
- Nutze die Vorteile der Wiederverwendbarkeit für Wartbarkeit und Konsistenz
