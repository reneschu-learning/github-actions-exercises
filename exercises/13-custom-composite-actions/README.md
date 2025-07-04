# Übung 13: Eigene Composite Actions

## Ziel
In dieser Übung lernst du, wie du eigene Composite Actions erstellst, die mehrere Schritte zu einer wiederverwendbaren Einheit zusammenfassen. Du extrahierst die Tagging-Funktionalität aus dem wiederverwendbaren Workflow aus Übung 12 und wandelst sie in eine Composite Action um, die in mehreren Workflows genutzt werden kann.

## Hintergrund
Composite Actions sind eine Möglichkeit, mehrere Workflow-Schritte zu einer wiederverwendbaren Action zu bündeln. Im Gegensatz zu wiederverwendbaren Workflows laufen Composite Actions im Kontext des aktuellen Jobs und sind ideal für:

- Kapselung häufiger Schrittfolgen
- Reduzierung von Duplikaten innerhalb von Jobs
- Wiederverwendbare Bausteine für Workflows
- Teilen von Logik ohne Job-Overhead

Vorteile von Composite Actions:
- **Keine Job-Grenzen**: Schritte laufen im selben Job-Kontext
- **Schnellere Ausführung**: Kein Job-Setup/Teardown-Overhead
- **Geteilter Kontext**: Zugriff auf dieselben Umgebungsvariablen und das Dateisystem
- **Einfacheres Debugging**: Alle Schritte erscheinen im selben Job-Log
- **Input/Output-Unterstützung**: Daten können in die Action hinein und heraus gegeben werden

## Was du lernst
- Wie man Composite Actions mit `action.yml` erstellt
- Wie man Inputs und Outputs für Composite Actions definiert
- Wie man Composite Actions in Workflows verwendet
- Wie man Actions für andere Repositories verfügbar macht
- Best Practices für Composite Actions

## Anleitung

### Schritt 1: Struktur der Composite Action anlegen
Lege ein neues Verzeichnis `.github/actions/create-release-tag/` in deinem Repository an. Hier kommt deine Composite Action für das Erstellen von Release-Tags hinein.

### Schritt 2: Action-Metadaten definieren
Erstelle eine `action.yml` in `.github/actions/create-release-tag/` mit folgenden Angaben:

1. **Metadaten:**
   - Name: "Create Release Tag"
   - Beschreibung: "Erstellt einen Git-Tag für Release-Deployments"
   - Autor: Dein Name oder Organisation

2. **Inputs:**
   - `tag-name`: (erforderlich) Name des zu erstellenden Tags
   - `commit-sha`: (erforderlich) Commit-SHA, der getaggt werden soll
   - `tag-message`: (optional) Nachricht für den Tag (Standard: "Release tag created by GitHub Actions")
   - `github-token`: (erforderlich) GitHub-Token für API-Zugriff

3. **Outputs:**
   - `tag-sha`: SHA des erstellten Tag-Objekts
   - `tag-url`: URL des erstellten Tags

### Schritt 3: Composite Action implementieren
Implementiere in der `action.yml` die Schritte, die:

1. Die Inputs validieren (prüfen, ob `tag-name` und `commit-sha` gesetzt sind)
2. Das Tag-Objekt mit der GitHub REST API erstellen
3. Die Tag-Referenz anlegen
4. Die Outputs mit den Tag-Informationen setzen
5. Hilfreiche Log-Meldungen ausgeben

### Schritt 4: Wiederverwendbaren Workflow aktualisieren
Passe deinen wiederverwendbaren Deployment-Workflow aus Übung 12 an, sodass er die neue Composite Action statt der Inline-Tagging-Schritte verwendet:

1. Ersetze den "Create Release Tag"-Schritt durch einen Aufruf deiner Composite Action
2. Übergebe die passenden Inputs
3. Nutze die Outputs der Action, falls benötigt

### Schritt 5: Composite Action testen
Erstelle einen Test-Workflow, der die Composite Action unabhängig demonstriert:

1. Erstelle `.github/workflows/test-composite-action.yml`
2. Füge einen manuellen Trigger (`workflow_dispatch`) hinzu
3. Definiere Inputs für Tag-Name und Ziel-Commit
4. Verwende deine Composite Action zum Erstellen eines Tags
5. Zeige die Outputs der Action an

### Schritt 6: Erweiterte Features (optional)
Erweitere deine Composite Action um zusätzliche Features:

1. Input-Validierung per Shell-Skript
2. Unterstützung für annotierte vs. Lightweight-Tags
3. Fehlerbehandlung und aussagekräftige Fehlermeldungen
4. Bedingte Logik je nach Inputs

## Wichtige Konzepte

### Composite Action Struktur
```yaml
name: 'Meine Composite Action'
description: 'Beschreibung der Action'
inputs:
  mein-input:
    description: 'Beschreibung des Inputs'
    required: true
    default: 'Standardwert'
outputs:
  mein-output:
    description: 'Beschreibung des Outputs'
    value: ${{ steps.step-id.outputs.value }}
runs:
  using: 'composite'
  steps:
    - name: Do something
      shell: bash
      run: echo "Hello from composite action"
```

### Verwendung von Composite Actions
```yaml
- name: Verwende meine Composite Action
  uses: ./.github/actions/my-action
  with:
    mein-input: 'irgendein-wert'
    github-token: ${{ secrets.GITHUB_TOKEN }}
```

### Input- und Output-Verwaltung
- Inputs werden über `${{ inputs.input-name }}` zugegriffen
- Outputs werden mit `echo "name=value" >> $GITHUB_OUTPUT` gesetzt
- Alle Schritte müssen eine `shell` angeben, wenn `run` verwendet wird

### Referenzierung von Actions
Bei der Verwendung von Actions in deinen Workflows kannst du sie auf verschiedene Weise referenzieren:
- Lokale Actions: `./.github/actions/action-name`
- Repository-Actions: `owner/repo@ref`

Wenn Actions aus einem anderen Repository referenziert werden, muss das Repository in der Regel öffentlich zugänglich sein (erforderlich, wenn die Action im GitHub Marketplace aufgeführt werden soll). Du kannst jedoch auch private Actions innerhalb deiner Organisation oder deines Unternehmens verwenden, indem du GitHub Actions den Zugriff auf das Repository der Action erlaubst. Gehe dazu zu den Repository-Einstellungen, navigiere zu "Actions" > "Allgemein" und wähle unter "Zugriff" die Option "Für Repositories in der '{deine Organisation}'-Organisation zugänglich" oder "Für Repositories in der '{dein Unternehmen}'-Unternehmen zugänglich".

## Erwartete Dateien
Nach Abschluss dieser Übung solltest du folgende Dateien haben:
- `.github/actions/create-release-tag/action.yml` - Die Definition der Composite Action
- `.github/workflows/reusable-deploy.yml` - Aktualisiert zur Verwendung der Composite Action
- `.github/workflows/test-composite-action.yml` - Test-Workflow für die Composite Action

## Tipps
- Halte Composite Actions auf eine einzige Verantwortung fokussiert
- Verwende klare, beschreibende Namen für Inputs und Outputs
- Füge umfassende Beschreibungen hinzu, um Benutzern das Verständnis der Action zu erleichtern
- Integriere Input-Validierung, um hilfreiche Fehlermeldungen bereitzustellen
- Teste deine Actions gründlich mit verschiedenen Input-Kombinationen
- Erwäge, deine Actions in deiner gesamten Organisation verfügbar zu machen

## Überprüfung
Um zu überprüfen, ob deine Lösung funktioniert:
1. Führe den Test-Workflow aus und bestätige, dass ein Tag erstellt wird
2. Überprüfe, ob der ursprüngliche Deployment-Workflow weiterhin funktioniert
3. Vergewissere dich, dass die Outputs der Composite Action korrekt gesetzt sind
4. Teste mit verschiedenen Input-Kombinationen
5. Stelle sicher, dass die Fehlerbehandlung korrekt funktioniert

## Sicherheitsüberlegungen
- Sei vorsichtig mit den Berechtigungen und dem Scoping von Tokens
- Validiere Inputs, um Injektionsangriffe zu verhindern
- Protokolliere keine sensiblen Informationen
- Verwende das Prinzip der geringsten Privilegien für Tokens

## Nächste Schritte
Nachdem du diese Übung abgeschlossen hast, hast du praktische Erfahrungen mit Composite Actions gesammelt und weißt, wie du benutzerdefinierte Actions innerhalb deiner Organisation oder deines Unternehmens teilen kannst. In der nächsten Übung lernst du, wie du auf Ressourcen in anderen Repositories zugreifst, was auch hilft, auf benutzerdefinierte Actions in Repositories zuzugreifen, die weder öffentlich sind noch allgemeinen Zugriff für GitHub Actions erlauben.
