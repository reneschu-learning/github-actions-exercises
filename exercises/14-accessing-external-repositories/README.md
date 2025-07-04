# Übung 14: Zugriff auf externe Repositories

## Ziel
In dieser Übung lernst du, wie du mit GitHub Apps in deinen Workflows auf externe Repositories zugreifst. Du erstellst eine GitHub App, konfigurierst sie mit einem privaten Schlüssel und verwendest die Action `actions/create-github-app-token@v1`, um ein Token zu generieren, mit dem dein Workflow mit Issues in einem anderen Repository interagieren kann.

## Voraussetzungen
- Zugriff auf eine GitHub-Organisation oder die Möglichkeit, eine zu erstellen
- Ein zweites Repository, mit dem interagiert werden soll (du kannst ein Test-Repository anlegen)

## Lernziele
Am Ende dieser Übung verstehst du:
- Wie man eine GitHub App erstellt und konfiguriert
- Wie man private Schlüssel sicher generiert und speichert
- Wie man die Action `actions/create-github-app-token@v1` verwendet
- Wie man mit GitHub Apps authentifiziert und mit externen Repositories interagiert
- Sicherheitsbest Practices beim Arbeiten mit GitHub Apps

## Hintergrund
Manchmal müssen Workflows mit anderen Repositories interagieren, z.B. um:
- Issues in einem Doku-Repository zu erstellen
- Einen Status in einem separaten Repository zu aktualisieren
- Workflows in anderen Repositories auszulösen
- Auf Code oder Daten aus privaten Repositories zuzugreifen

Ein Personal Access Token (PAT) wäre möglich, aber GitHub Apps sind sicherer und skalierbarer:
- **Granulare Berechtigungen**: Zugriff kann genau gesteuert werden
- **Installationsbasiert**: Die App ist nur dort installiert, wo sie gebraucht wird
- **Organisationsebene**: Organisationseigentümer verwalten App-Installationen
- **Audit Trail**: Alle Aktionen werden der App zugeordnet
- **Token-Ablauf**: Tokens sind kurzlebig und werden automatisch erneuert

## Schritt 1: Ziel-Repository anlegen
Lege ein Test-Repository an, mit dem dein Workflow interagieren soll:

1. Erstelle ein neues Repository in deiner Organisation (oder deinem Account), z.B. `external-repo-test`
2. Öffentlich, privat oder intern (je nach Bedarf)
3. Notiere dir den vollständigen Namen (z.B. `deine-org/external-repo-test`)

## Schritt 2: GitHub App erstellen
1. **Zu den GitHub App-Einstellungen navigieren**:
   - Gehe zu den Organisationseinstellungen (oder Account-Einstellungen)
   - Klicke links auf "Developer settings"
   - Klicke auf "GitHub Apps"
   - Klicke auf "New GitHub App"

2. **GitHub App konfigurieren**:
   - **Name:** z.B. `External Repo Access App` (muss global eindeutig sein)
   - **Beschreibung:** `App für den Zugriff auf externe Repositories in Workflows`
   - **Homepage URL:** `https://localhost` (Platzhalter reicht)
   - **Webhook:** Deaktiviert lassen

3. **Berechtigungen setzen**:
   Unter "Repository permissions":
   - **Issues**: Write
   - **Metadata**: Read
   - **Contents**: Read

4. **Installationsoptionen wählen**:
   - "Only on this account" auswählen

5. **App erstellen**:
   - Klicke auf "Create GitHub App"
   - Notiere die **App ID**

## Schritt 3: Privaten Schlüssel generieren und herunterladen
1. **Privaten Schlüssel generieren**:
   - In den App-Einstellungen auf "Private keys" gehen
   - "Generate a private key" klicken
   - Die `.pem`-Datei herunterladen

2. **Privaten Schlüssel vorbereiten**:
   - Öffne die `.pem`-Datei im Editor
   - Kopiere den gesamten Inhalt (inkl. BEGIN/END)

## Schritt 4: GitHub App installieren
1. **App installieren**:
   - In den App-Einstellungen auf "Install App"
   - "Install" neben deiner Organisation/deinem Account
   - "Selected repositories" wählen und das Ziel-Repository auswählen
   - "Install" klicken

## Schritt 5: Repository-Secrets konfigurieren
Im Workflow-Repository:

1. **Secrets hinzufügen**:
   - Gehe zu Settings → Secrets and variables → Actions
   - "New repository secret" klicken
   - **Name:** `APP_ID`, **Wert:** App ID
   - **Name:** `APP_PRIVATE_KEY`, **Wert:** kompletter privater Schlüssel

## Schritt 6: Workflow erstellen
Erstelle eine Workflow-Datei `.github/workflows/external-repo-access.yml` mit folgenden Anforderungen:

1. **Trigger:** Manueller Trigger (`workflow_dispatch`) mit Inputs:
   - `target_repo`: Das Repository, in dem ein Issue erstellt werden soll (Standard: das Test-Repository)
   - `issue_title`: Titel für das zu erstellende Issue
   - `issue_body`: Inhalt für das zu erstellende Issue

2. **Jobs**:
   - Ein einzelner Job, der die GitHub App verwendet, um ein Issue im Ziel-Repository zu erstellen

3. **Steps**:
   - Generiere ein Token mit der GitHub App
   - Erstelle ein Issue im Ziel-Repository mit der GitHub CLI
   - Gebe die URL des erstellten Issues aus

## Schritt 7: Workflow testen
1. **Workflow auslösen**:
   - Gehe zu Actions → External Repo Access → Run workflow
   - Gib die Inputs ein:
     - Ziel-Repo: `deine-org/external-repo-test`
     - Issue-Titel: `Test-Issue von Workflow`
     - Issue-Body: `Dieses Issue wurde von einem GitHub Actions-Workflow mit einem GitHub App-Token erstellt.`

2. **Ergebnisse überprüfen**:
   - Überprüfe, ob der Workflow erfolgreich durchgelaufen ist
   - Verifiziere, dass ein Issue im Ziel-Repository erstellt wurde
   - Bestätige, dass das Issue deiner GitHub App zugeordnet ist

## Sicherheitshinweise
- Private Schlüssel niemals in Logs oder Code speichern
- Tokens sind kurzlebig und werden pro Workflow-Lauf generiert
- Berechtigungen der App so restriktiv wie möglich halten

## GitHub App vs. Personal Access Token
- **GitHub Apps** sind bevorzugt für die Nutzung in Organisationen, weil:
  - Sie nicht von individuellen Benutzerkonten abhängen
  - Sie bessere Audit Trails bieten
  - Sie granularere Berechtigungen haben
  - Sie auf Organisationsebene verwaltet werden können

## Erweiterte Nutzung
Mit dem generierten Token kannst du auch private Actions aus anderen Repositories nutzen, indem du das Repository mit dem Token klonst und die Action lokal verwendest.

## Nächste Schritte
Teste den Workflow und prüfe, ob das Issue im Ziel-Repository erstellt wird. Erweitere die App-Berechtigungen, falls du weitere Aktionen benötigst.
