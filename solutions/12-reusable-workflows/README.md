# Lösung: Übung 12 – Wiederverwendbare Workflows

Diese Lösung zeigt, wie man eine CI/CD-Pipeline mit wiederverwendbaren Workflows refaktoriert, um Duplikate zu vermeiden und die Wartbarkeit zu verbessern.

## Dateien
- `ci-cd-pipeline.yml`: Haupt-Workflow, der wiederverwendbare Workflows aufruft
- `reusable-deploy.yml`: Wiederverwendbarer Deployment-Workflow

## Überblick

### 🔄 Wiederverwendbarer Deployment-Workflow (`reusable-deploy.yml`)
**Zweck**: Deployment in beliebige Environments mit konfigurierbaren Parametern.

**Inputs**:
- `environment` (erforderlich): Ziel-Environment (development/production)
- `package-name` (erforderlich): Name des zu deployenden Artefakts
- `app-url` (erforderlich): URL, unter der die Anwendung bereitgestellt wird
- `is-production` (optional): Boolean-Flag für produktspezifische Schritte

**Outputs**:
- `deployment-status`: Erfolgs- oder Fehlerstatus

**Features**:
- Environment-spezifisches Deployment
- Bedingte Production-Schritte (Anwendung starten, Release-Tag erstellen)
- Deployment-Zusammenfassungen mit Metadaten
- Artefakt-Download und Verifikation

### 🔗 Haupt-Workflow (`ci-cd-pipeline.yml`)

**Änderungen gegenüber Übung 9**:
- `build`- und `package`-Jobs bleiben unverändert
- `deploy-dev` ruft jetzt `reusable-deploy.yml` mit Entwicklungsparametern auf
- `deploy-prod` ruft jetzt `reusable-deploy.yml` mit Produktionsparametern auf
- `notify`-Job nutzt die Outputs der wiederverwendbaren Deployment-Workflows

## Wichtige Features

### 1. Workflow-Calls
```yaml
deploy-dev:
  uses: ./.github/workflows/reusable-deploy.yml
  with:
    environment: 'development'
    package-name: 'deployment-package'
    app-url: 'https://dev-sampleapp.example.com'
  secrets: inherit
```

### 2. Input/Output-Management
**Inputs** ermöglichen Parametrisierung:
```yaml
on:
  workflow_call:
    inputs:
      environment:
        required: true
        type: string
        description: 'Ziel-Environment'
```

**Outputs** ermöglichen Datenaustausch:
```yaml
outputs:
  deployment-status:
    description: 'Status des Deployments'
    value: ${{ jobs.deploy.outputs.status }}
```

### 3. Bedingte Logik
Produktspezifische Schritte mit Input-Flags:
```yaml
- name: 🔧 .NET Setup (nur Produktion)
  if: inputs.is-production
  uses: actions/setup-dotnet@v4
```

### 4. Status-Weitergabe
Verwendung von Job-Outputs im Benachrichtigungsjob:
```yaml
with:
  dev-status: ${{ needs.deploy-dev.outputs.deployment-status }}
  prod-status: ${{ needs.deploy-prod.outputs.deployment-status }}
```

### 5. Berechtigungsvererbung
```yaml
permissions:
  contents: write
secrets: inherit
```

## Vorteile

### ✅ Weniger Duplikate
- Deployment-Logik nur einmal geschrieben, mehrfach genutzt
- Benachrichtigungslogik zentralisiert
- Konsistentes Verhalten in allen Environments

### ✅ Bessere Wartbarkeit  
- Änderungen am Deployment-Prozess nur an einer Stelle nötig
- Klare Trennung der Verantwortlichkeiten
- Einfacher zu testende Einzelkomponenten

### ✅ Bessere Organisation
- Fokussierte Workflows mit einzelnen Verantwortlichkeiten
- Klare Input-/Output-Verträge
- Wiederverwendbar in mehreren Projekten

### ✅ Verbesserte Flexibilität
- Parametrisiertes Deployment
- Environment-spezifische Konfigurationen
- Einfaches Hinzufügen neuer Environments
