# Lösung: Übung 9 – Vollständige CI/CD-Pipeline

Diese Lösung demonstriert eine vollständige CI/CD-Pipeline für eine .NET-Anwendung mit mehreren Stufen, Matrix-Strategien und Deployments in verschiedene Environments.

## Dateien
- `ci-cd-pipeline.yml`: Vollständiger CI/CD-Pipeline-Workflow
- Die Beispielanwendung befindet sich im Übungsordner

## Pipeline-Überblick

### 🛠️ Build- und Test-Job
- **Matrix-Strategie**: Tests gegen .NET 8.0 und 9.0
- **Verwendete Actions**: `actions/checkout@v4`, `actions/setup-dotnet@v4`, `actions/upload-artifact@v4`
- **Ablauf**: Checkout → .NET Setup → Restore → Build → Test → Artefakte hochladen
- **Artefakte**: Build-Outputs und Testergebnisse für jede .NET-Version
- **Features**:
  - Unit-Tests mit xUnit
  - Testergebnisse im TRX-Format
  - Code Coverage
  - Upload der Testergebnis-Artefakte

### 📦 Package-Job
- **Abhängigkeit**: Benötigt Build-Job
- **Bedingung**: Läuft nur bei Nicht-PR-Events
- **Verwendete Actions**: `actions/checkout@v4`, `actions/setup-dotnet@v4`, `actions/upload-artifact@v4`
- **Ablauf**:
  - Lädt Build-Artefakte herunter
  - Veröffentlicht Anwendung für Deployment
  - Erstellt Deployment-Paket mit Metadaten

### 🚀 Deploy-Jobs

#### Deployment Entwicklung
- **Trigger**: Push auf main oder manueller Aufruf
- **Environment**: Nutzt GitHub Environments
- **Verwendete Actions**: `actions/download-artifact@v4`
- **Features**:
  - Environment-URL-Konfiguration
  - Build-Info-Anzeige
  - Deployment-Zusammenfassung (`GITHUB_STEP_SUMMARY`)

#### Deployment Produktion
- **Abhängigkeit**: Benötigt Entwicklung-Deployment
- **Bedingung**: Manuelle Auswahl für Produktion
- **Verwendete Actions**: `actions/setup-dotnet@v4`, `actions/download-artifact@v4`
- **Features**:
  - Environment-URL-Konfiguration
  - Build-Info-Anzeige
  - Anwendung ausführen
  - Release-Tag mit GitHub REST API erstellen

### 📢 Benachrichtigungs-Job
- **Abhängigkeit**: Läuft nach den Deployments
- **Bedingung**: Läuft immer, wenn ein Deployment stattfand
- **Features**: Statusbenachrichtigungen für alle Environments

## Wichtige Features

### 1. Job-Abhängigkeiten
```yaml
needs: [ deploy-dev, deploy-prod ]
```
Steuert die Ausführungsreihenfolge und stellt sicher, dass Stufen nur nach Erfüllung der Voraussetzungen laufen.

### 2. Matrix-Strategien
```yaml
strategy:
  matrix:
    dotnet-version: ['8.0.x', '9.0.x']
```
Build und Tests parallel für mehrere .NET-Versionen.

### 3. Bedingte Ausführung
```yaml
if: github.ref == 'refs/heads/main'
```
Steuert, wann Deployments je nach Branch und Trigger erfolgen.

### 4. Artefaktmanagement
- Build-Artefakte werden zwischen Jobs geteilt
- Testergebnisse werden für Analysen gespeichert
- Deployment-Pakete mit Metadaten
- Aufbewahrungsrichtlinien für Speicheroptimierung

### 5. Environment-Integration
- Environment-spezifische Konfigurationen
- Unterstützung für Schutzregeln
- Environment-URLs für schnellen Zugriff
- Manuelle Freigabe-Workflows (falls konfiguriert)

### 6. GitHub Actions Features
- Step-Summaries für Deployment-Status
- Emojis für bessere Lesbarkeit
- Realistische Zeitsteuerung mit sleep
- Umfassendes Logging und Status-Reporting

## Trigger

### Automatische Trigger
- **Push auf main**: Volle Pipeline mit Entwicklung-Deployment
- **Pull Request auf main**: Build und Test
- **Manueller Trigger**: Auswahl des Environments möglich

## Vorteile
- Vollständige Automatisierung von Build, Test und Deployment
- Übersichtliche Struktur und klare Abhängigkeiten
- Einfache Erweiterbarkeit für weitere Environments oder Stufen

## Nächste Schritte
In der nächsten Übung wird die Pipeline um ein Azure Deployment mit Service Principal erweitert.
