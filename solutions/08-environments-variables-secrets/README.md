# Lösung: Übung 8 – Environments, Variablen und Secrets

Diese Lösung zeigt, wie man Environments, Variablen und Secrets in GitHub Actions Workflows verwendet.

## Dateien
- `environments-variables-secrets.yml`: Die Haupt-Workflow-Datei

## Wichtige Merkmale

### 1. Workflow-Inputs
- Verwendet den `workflow_dispatch` Trigger mit zwei Inputs
- `environment`: Auswahlfeld für das Ziel-Environment
- `deploy_version`: String-Input für die Deployment-Version

### 2. Verwendung von Environments
- Der Job verwendet das im Input angegebene Environment: `environment: ${{ inputs.environment }}`
- Dadurch kann der Workflow auf environment-spezifische Variablen und Secrets zugreifen

### 3. Variablen-Demonstration
- Zeigt, wie man Repository-Variablen abruft: `${{ vars.VARIABLE_NAME }}`
- Zeigt, wie man Umgebungsvariablen abruft (gleiche Syntax, aber Environment überschreibt Repository)
- Demonstriert die Priorität von Variablen (Environment überschreibt Repository)
- Zeigt, wie man lokale Variablen im Workflow mit `env` definiert und mit `${{ env.VARIABLE_NAME }}` abruft
  - **Hinweis:** Lokale Variablen sind nicht im Job-Environment verfügbar, sondern nur innerhalb der Workflow-Schritte. Sie können nicht als Inputs für wiederverwendbare Workflows verwendet werden.

### 4. Verwendung von Secrets
- Zeigt, wie man Secrets sicher verwendet, ohne Werte preiszugeben
- Secret-Werte werden automatisch in Logs maskiert
- Verwendet bedingte Prüfung, um zu prüfen, ob ein Secret existiert: `${{ secrets.SECRET_NAME != '' }}`

## Setup-Anleitung

### Repository-Variablen
Lege diese unter **Settings > Secrets and variables > Actions > Variables** an:
- `APP_NAME`: `my-awesome-app`
- `DEFAULT_REGION`: `us-east-1`

### Environments
Lege diese unter **Settings > Environments** an:

#### Development Environment
- Umgebungsvariablen:
  - `ENVIRONMENT_NAME`: `dev`
  - `API_URL`: `https://dev-api.example.com`
- Environment-Secrets:
  - `DATABASE_PASSWORD`: `dev-password-123`

#### Production Environment
- Umgebungsvariablen:
  - `ENVIRONMENT_NAME`: `prod`
  - `API_URL`: `https://api.example.com`
- Environment-Secrets:
  - `DATABASE_PASSWORD`: `prod-password-xyz`
- Schutzregeln:
  - Erforderliche Reviewer
  - Wartezeit: 5 Minuten

### Repository-Secrets
Lege diese unter **Settings > Secrets and variables > Actions > Secrets** an:
- `API_KEY`: `super-secret-api-key-12345`

## Testen
1. Starte den Workflow mit dem Environment `development` – sollte sofort ausgeführt werden
2. Starte den Workflow mit dem Environment `production` – benötigt Freigabe und Wartezeit
3. Vergleiche die Ausgabe, um zu sehen, wie Umgebungsvariablen Repository-Variablen überschreiben

## Sicherheits-Best-Practices
- Secrets werden automatisch in Logs maskiert
  - **Hinweis:** Das Maskieren von Secrets bietet nur bestmöglichen Schutz. Secrets können trotzdem über Artefakte, transformierte Werte in Logs oder andere Wege offengelegt werden. Wenn möglich, vermeide die Verwendung von Secrets in Workflows. Beispiel: [Übung 11](./exercises/11-full-ci-cd-pipeline-azure-deployment-oidc/README.md) zeigt, wie man OIDC-Authentifizierung nutzt, um beim Azure-Login keine Secrets zu verwenden.
- Environment-Schutzregeln verhindern unautorisierte Production-Deployments
- Trennung der Konfiguration zwischen Environments
- Sicherer Umgang mit sensiblen Informationen
