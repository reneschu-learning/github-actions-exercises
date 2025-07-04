# Lösung: Übung 14 – Zugriff auf externe Repositories

Dieses Verzeichnis enthält die Lösung für Übung 14 und zeigt, wie man mit GitHub Apps in Workflows auf externe Repositories zugreift.

## Überblick
Die Lösung demonstriert:
- Erstellen und Konfigurieren einer GitHub App mit passenden Berechtigungen
- Verwendung der Action `actions/create-github-app-token@v1` zur Token-Generierung
- Erstellen von Issues in externen Repositories mit der GitHub CLI
- Fehlerbehandlung und Sicherheitspraktiken

## Enthaltene Dateien
- `external-repo-access.yml`: Vollständiger Workflow, der mit GitHub App-Authentifizierung Issues in externen Repositories erstellt

## Wichtige Details
### GitHub App-Konfiguration
Die Lösung geht von einer GitHub App mit folgenden Berechtigungen aus:
- **Repository permissions**:
  - Issues: Write
  - Metadata: Read
  - Contents: Read
- **Installation**: Auf Ziel-Repositories installiert

### Benötigte Secrets
Der Workflow benötigt zwei Repository-Secrets:
- `APP_ID`: Die GitHub App ID (numerisch)
- `APP_PRIVATE_KEY`: Der komplette private Schlüssel (inkl. BEGIN/END)

### Sicherheitsfeatures
- Privater Schlüssel wird nie in Logs ausgegeben
- Token wird für jeden Lauf neu generiert
- Fehlerbehandlung verhindert das Leaken sensibler Daten
- Korrekte Validierung von Inputs und Outputs

## Nutzung der Lösung
1. **GitHub App einrichten**: Anleitung in der Übung befolgen
2. **Secrets konfigurieren**: `APP_ID` und `APP_PRIVATE_KEY` als Repository-Secrets anlegen
3. **Workflow deployen**: Workflow-Datei nach `.github/workflows/` kopieren
4. **Testen**: Workflow manuell mit passenden Inputs ausführen

## Testen der Lösung
1. **Manueller Trigger**:
   ```
   Repository: deine-org/ziel-repo
   Issue-Titel: Test-Issue von GitHub App
   Issue-Body: Demonstration des externen Zugriffs
   ```

2. **Erwartetes Ergebnis**:
   - Workflow läuft erfolgreich durch
   - Neues Issue erscheint im Ziel-Repository
   - Issue wird der GitHub App zugeordnet
   - Workflow-Ausgabe zeigt die Issue-URL

## Erweiterte Nutzung
Mit dem generierten Token kannst du auch private Actions aus anderen Repositories nutzen, indem du das Repository mit dem Token klonst und die Action lokal verwendest:

```yaml
steps:
  - name: GitHub App Token generieren
    id: generate-token
    uses: actions/create-github-app-token@v1
    with:
      app-id: ${{ secrets.APP_ID }}
      private-key: ${{ secrets.APP_PRIVATE_KEY }}
      repositories: deine-org/private-action-repo

  - name: Action-Repository auschecken
    uses: actions/checkout@v4
    with:
      repository: deine-org/private-action-repo
      token: ${{ steps.generate-token.outputs.token }}
      path: private-action-repo

  - name: Private Action lokal ausführen
    uses: ./private-action-repo/
    with:
      some-input: 'Wert'
```
