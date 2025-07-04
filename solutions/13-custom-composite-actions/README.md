# Lösung: Übung 13 – Eigene Composite Actions

## Überblick
Diese Lösung zeigt, wie man eine eigene Composite Action erstellt, die die Tagging-Funktionalität aus Übung 12 kapselt. Die Composite Action bietet eine wiederverwendbare Möglichkeit, Git-Tags mit Fehlerbehandlung und Outputs zu erstellen.

## Erstellte Dateien

### 1. Composite Action (`.github/actions/create-release-tag/action.yml`)
Die Haupt-Composite Action für das Tagging mit:
- Input-Validierung
- GitHub API-Integration
- Fehlerbehandlung
- Strukturierte Outputs

### 2. Aktualisierter wiederverwendbarer Workflow (`reusable-deploy.yml`)
Angepasste Version des Workflows aus Übung 12, die die neue Composite Action statt Inline-Tagging verwendet.

### 3. Test-Workflow (`test-composite-action.yml`)
Eigenständiger Workflow zum Testen der Composite Action, der zeigt, wie sie in verschiedenen Kontexten genutzt werden kann.

## Wichtige Features

### Composite Action Features
- **Input-Validierung**: Stellt sicher, dass erforderliche Inputs gesetzt sind
- **Flexibles Tagging**: Unterstützt eigene Tag-Namen und Nachrichten
- **Fehlerbehandlung**: Liefert aussagekräftige Fehlermeldungen
- **Strukturierte Outputs**: Gibt Tag-SHA und URL zurück
- **API-Integration**: Nutzt die GitHub REST API für das Tagging

### Vorteile
- **Wiederverwendbarkeit**: Tagging-Logik kann in mehreren Workflows genutzt werden
- **Wartbarkeit**: Änderungen an der Tagging-Logik nur an einer Stelle nötig
- **Testbarkeit**: Composite Action kann unabhängig getestet werden
- **Klarheit**: Workflow-Schritte sind übersichtlicher

## Anwendungsbeispiele

### Im Workflow
```yaml
- name: Release-Tag erstellen
  uses: ./.github/actions/create-release-tag
  with:
    tag-name: 'v1.0.0'
    commit-sha: ${{ github.sha }}
    tag-message: 'Release v1.0.0'
    github-token: ${{ secrets.GITHUB_TOKEN }}
```

### Mit dynamischen Tag-Namen
```yaml
- name: Release-Tag erstellen
  uses: ./.github/actions/create-release-tag
  with:
    tag-name: 'v1.0.${{ github.run_number }}'
    commit-sha: ${{ github.sha }}
    github-token: ${{ secrets.GITHUB_TOKEN }}
```

## Testen
Die Lösung enthält umfassende Tests durch:
1. Manuellen Test über den Test-Workflow
2. Integrationstest über den aktualisierten wiederverwendbaren Workflow
3. Fehlerfall-Tests mit ungültigen Inputs

## Erweiterungsideen
- Unterstützung für Pre-Release-Tags
- Integration mit Release Notes
- Unterstützung verschiedener Tag-Formate
- Benachrichtigungsfunktionen
- Rollback-Funktionalität

## Best Practices
- Klare Input/Output-Definitionen
- Umfassende Fehlerbehandlung
- Aussagekräftige Log-Meldungen
- Sicherer Umgang mit Tokens
- Modulares Design
