# Übung 8: Environments, Variablen und Secrets

## Lernziele
In dieser Übung lernst du:
- Wie du Environments erstellst und verwendest, um den Zugriff auf Jobs zu steuern
- Wie du Repository- und Umgebungsvariablen verwendest
- Wie du *lokale* Umgebungsvariablen für wiederverwendbare Werte im Workflow nutzt (oder um Skript-Injektion zu vermeiden)
- Wie du Secrets sicher in Workflows speicherst und verwendest
- Wie die Priorität von Variablen und Secrets funktioniert
- Wie du Schutzregeln für Environments konfigurierst

## Hintergrund
Environments, Variablen und Secrets sind essenzielle Bestandteile für das Management von Konfiguration und sensiblen Daten in GitHub Actions Workflows. Sie ermöglichen dir:
- Konfigurationen für verschiedene Deployment-Stufen (dev, staging, production) zu trennen
- Sensible Informationen wie API-Keys, Passwörter und Tokens sicher zu speichern
- Den Zugriff auf bestimmte Environments mit Schutzregeln zu kontrollieren
- Unterschiedliche Konfigurationen für verschiedene Branches oder Deployments zu pflegen

## Anleitung

### Teil 1: Repository-Variablen erstellen
1. Gehe in deinem Repository zu **Settings > Secrets and variables > Actions**
2. Klicke auf den Tab **Variables**
3. Erstelle folgende Repository-Variablen:
   - `APP_NAME`: Setze auf `my-awesome-app`
   - `DEFAULT_REGION`: Setze auf `us-east-1`

### Teil 2: Environments und Umgebungsvariablen erstellen
1. Gehe zu **Settings > Environments**
2. Erstelle zwei Environments:
   - `development`
   - `production`
3. Für das Environment `development`:
   - Füge die Umgebungsvariable `ENVIRONMENT_NAME`: `dev` hinzu
   - Füge die Umgebungsvariable `API_URL`: `https://dev-api.example.com` hinzu
4. Für das Environment `production`:
   - Füge die Umgebungsvariable `ENVIRONMENT_NAME`: `prod` hinzu
   - Füge die Umgebungsvariable `API_URL`: `https://api.example.com` hinzu
   - Konfiguriere Schutzregeln:
     - Erforderliche Reviewer: Füge dich selbst hinzu
     - Wartezeit: 1 Minute

### Teil 3: Secrets erstellen
1. Gehe zurück zu **Settings > Secrets and variables > Actions**
2. Klicke auf den Tab **Secrets**
3. Erstelle ein Repository-Secret:
   - `API_KEY`: Setze auf `super-secret-api-key-12345`
4. Für jedes Environment (`development` und `production`):
   - Füge das Environment-Secret `DATABASE_PASSWORD` hinzu:
     - Development: `dev-password-123`
     - Production: `prod-password-xyz`

### Teil 4: Workflow erstellen
Erstelle eine Workflow-Datei `.github/workflows/environments-variables-secrets.yml` mit folgenden Anforderungen:

1. **Trigger**: Manueller Trigger mit Inputs:
   - `environment`: Auswahlfeld mit den Optionen `development` und `production`
   - `deploy_version`: String-Input für die Versionsnummer

2. **Lokale Variablen**:
   - Verwende `env`, um lokale Variablen im Workflow zu definieren
   - Beispiel: `actor: ${{ github.actor }}`

3. **Jobs**:
   - `deploy`:
     - Nutzt das im Input angegebene Environment
     - Zeigt alle Variablen und Secrets an
     - Zeigt die Priorität von Variablen (Repository vs. Environment)

### Teil 5: Workflow testen
1. Starte den Workflow manuell und wähle das Environment `development`
2. Beobachte, wie Variablen und Secrets abgerufen werden
3. Starte den Workflow erneut mit dem Environment `production`
4. Beachte die Schutzregeln für das Production-Environment

## Erwartetes Ergebnis
Nach Abschluss dieser Übung solltest du:
- Einen Workflow haben, der den Umgang mit Environments, Variablen und Secrets demonstriert
- Verstehen, wie Environment-Schutzregeln funktionieren
- Wissen, wie die Priorität von Variablen und Secrets funktioniert
- Erfahrung mit verschiedenen Typen von Variablen und Secrets haben

## Wichtige Konzepte
- **Repository-Variablen**: Für alle Environments und Workflows verfügbar
- **Umgebungsvariablen**: Spezifisch für ein Environment, überschreiben Repository-Variablen
- **Repository-Secrets**: Für alle Environments und Workflows verfügbar
- **Environment-Secrets**: Spezifisch für ein Environment, überschreiben Repository-Secrets
- **Environment-Schutzregeln**: Steuern den Zugriff auf Environments
- **Variablen-Priorität**: Environment > Repository
- **Secret-Priorität**: Environment > Repository

## Tipps
- Verwende für sensible Informationen immer Secrets, niemals Variablen
- Umgebungsvariablen und Secrets überschreiben Repository-Variablen und -Secrets
- Schutzregeln für Environments sind für Production-Deployments entscheidend
- Verwende aussagekräftige Namen für Variablen und Secrets
- Teste mit beiden Environments, um die Unterschiede zu sehen

## Nächste Schritte
In der nächsten Übung baust du eine vollständige CI/CD-Pipeline, die diese Konzepte mit Build, Test und Deployment kombiniert.
