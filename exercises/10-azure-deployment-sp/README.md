# Übung 10: Einfacher Workflow mit Azure Deployment (Service Principal)
In dieser Übung erstellst du einen GitHub Actions Workflow, der Ressourcen in Azure mit einem Service Principal für die Authentifizierung bereitstellt. Du lernst, wie man einen Service Principal erstellt und konfiguriert, Repository-Secrets einrichtet und Azure-Ressourcen mit GitHub Actions bereitstellt.

## Voraussetzungen
- Ein Azure-Abonnement mit Berechtigungen zum Erstellen von Ressourcen und Service Principals
- Azure CLI lokal installiert (für die Setup-Schritte)

## Lernziele
Am Ende dieser Übung kannst du:
- Einen Azure Service Principal für GitHub Actions erstellen und konfigurieren
- Repository-Secrets für sichere Authentifizierung einrichten
- Die Action `azure/login` zur Authentifizierung mit Azure verwenden
- Azure-Ressourcen mit GitHub Actions bereitstellen
- Die Sicherheitsaspekte der Service Principal-Authentifizierung verstehen

## Überblick
Diese Übung führt dich durch:
1. Erstellen eines Service Principals in Azure
2. Konfigurieren von Repository-Secrets in GitHub
3. Erstellen eines Workflows, der grundlegende Azure-Ressourcen bereitstellt
4. Verstehen der Berechtigungen und Sicherheit eines Service Principals

## Schritt 1: Erstelle einen Azure Service Principal
Zuerst musst du einen Service Principal erstellen, den GitHub Actions zur Authentifizierung mit Azure verwenden kann.

### 1.1 Anmeldung bei der Azure CLI
Öffne dein Terminal oder die Eingabeaufforderung und melde dich bei Azure an:

```bash
az login
```

### 1.2 Setze dein Abonnement (falls du mehrere hast)
```bash
az account set --subscription "Dein Abonnementname oder ID"
```

### 1.3 Erstelle einen Service Principal
Erstelle einen Service Principal mit Contributor-Rechten für dein Abonnement:

```bash
az ad sp create-for-rbac --name "github-actions-sp" --role contributor --scopes /subscriptions/{subscription-id} --json-auth
```

**Hinweis:** Wenn mehrere Personen diese Übung im selben Entra ID Tenant durchführen, verwende einen eindeutigen Namen für deinen Service Principal (z.B. mit GitHub-Benutzernamen oder Zufallsstring).

Ersetze `{subscription-id}` durch deine tatsächliche Abonnement-ID. Du findest sie mit:

```bash
az account show --query id --output tsv
```

**Wichtig:** Speichere die JSON-Ausgabe des Befehls, du benötigst sie im nächsten Schritt.

Die Ausgabe sieht so aus:
```json
{
  "clientId": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",
  "clientSecret": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",
  "subscriptionId": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",
  "tenantId": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",
  "activeDirectoryEndpointUrl": "https://login.microsoftonline.com",
  "resourceManagerEndpointUrl": "https://management.azure.com/",
  "activeDirectoryGraphResourceId": "https://graph.windows.net/",
  "sqlManagementEndpointUrl": "https://management.core.windows.net:8443/",
  "galleryEndpointUrl": "https://gallery.azure.com/",
  "managementEndpointUrl": "https://management.core.windows.net/"
}
```

## Schritt 2: Repository-Secrets konfigurieren
Jetzt musst du die Service Principal-Zugangsdaten als Secrets in deinem GitHub-Repository speichern.

### 2.1 Navigiere zu den Repository-Einstellungen
1. Gehe zu deinem GitHub-Repository
2. Klicke auf den Tab **Settings**
3. In der linken Seitenleiste: **Secrets and variables → Actions**

### 2.2 Repository-Secrets hinzufügen
Klicke auf **New repository secret** und füge folgende Secrets hinzu:

1. **Name:** `AZURE_CREDENTIALS`
   **Wert:** Die gesamte JSON-Ausgabe aus Schritt 1.3

   **Hinweis:** Die Action `azure/login` benötigt nur `clientId`, `clientSecret`, `tenantId` und `subscriptionId` aus dem JSON. Die restlichen Felder können entfernt werden.

2. **Name:** `AZURE_SUBSCRIPTION_ID` (optional)
   **Wert:** Deine Azure-Abonnement-ID

   **Hinweis:** Die Subscription-ID ist nicht sensibel und kann auch als Repository-Variable gespeichert werden.

**Hinweis:** In der Praxis werden Secrets meist in Environments gespeichert, um verschiedene Identitäten je nach Zielumgebung zu nutzen (z.B. dev, staging, prod).

## Schritt 3: Workflow erstellen
Erstelle eine Workflow-Datei `.github/workflows/azure-deployment-sp.yml` mit folgendem Inhalt:

### 3.1 Trigger
Konfiguriere den Workflow für einen manuellen Trigger mit Inputs für Resource Group Name, Storage Account Name und Storage Container Name.

### 3.2 Workflow-Inhalt
1. Authentifiziere dich bei Azure mit der [azure/login@v2](https://github.com/Azure/login/tree/v2?tab=readme-ov-file#login-with-a-service-principal-secret) Action
2. Erstelle eine Resource Group mit der Azure CLI
3. Erstelle ein Storage-Konto innerhalb der Resource Group und einen Container innerhalb dieses Kontos
4. Liste die erstellten Ressourcen zur Überprüfung auf

## Schritt 4: Teste den Workflow
Trigger den Workflow und gib Namen für die Ressourcen an (z.B. `rg-github-actions-workshop`, `sagithubactions`, `sampledata`).

Beobachte die Ausführung des Workflows und überprüfe, ob:
- Der Anmeldeschritt erfolgreich ist
- Die Resource Group erstellt wird
- Das Storage-Konto erstellt wird
- Der Storage-Container erstellt wird
- Alle Ressourcen am Ende aufgelistet werden

## Schritt 5: Überprüfen im Azure Portal

1. Gehe zum [Azure Portal](https://portal.azure.com)
2. Navigiere zur Resource Group
3. Finde die von deinem Workflow erstellte Resource Group
4. Überprüfe, ob das Storage-Konto und der Container erfolgreich erstellt wurden

## Schritt 6: Bereinigung (Optional)
Um Azure-Kosten zu vermeiden, kannst du einen Bereinigungs-Workflow erstellen oder die Ressourcen manuell löschen:

### Manuelle Bereinigung:
```bash
az group delete --name {your-resource-group-name} --yes --no-wait
```

Ersetze `{your-resource-group-name}` durch den Namen der von dir erstellten Resource Group.

### Automatische Bereinigung (optional)
Wenn du mehr Zeit hast, füge einen Bereinigungsjob zu deinem Workflow hinzu, der die Ressourcen löscht, nachdem die Bereitstellung überprüft wurde. Verwende ein Environment mit einer Genehmigung von dir für diesen Job, um sicherzustellen, dass du genügend Zeit hast, die Ressourcen zu überprüfen, bevor sie gelöscht werden.

## Sicherheitshinweise
Bei der Verwendung von Service Principals zur Authentifizierung:

1. **Prinzip der geringsten Berechtigung:** Gewähre nur die minimal erforderlichen Berechtigungen
2. **Geheimnisrotation:** Drehe regelmäßig die Secrets des Service Principals
3. **Geheimnisverwaltung:** Speichere keine Secrets im Repository
4. **Überwachung:** Überwache die Nutzung und Zugriffs Muster des Service Principals
5. **Einschränkung des Zugriffs:** Beschränke den Zugriff des Service Principals auf bestimmte Resource Groups, wenn möglich

Denke daran, dass Workflows, die Service Principals mit Client-ID und Secret verwenden, anfällig für Geheimnisdiebstahl/-leckagen sind. Vermeide nach Möglichkeit die Verwendung von Secrets für deine Bereitstellungen und wechsle zu sichereren Methoden wie der OpenID Connect (OIDC) Authentifizierung.

## Nächste Schritte
In der nächsten Übung lernst du, wie du OpenID Connect (OIDC) Authentifizierung verwendest, die die Speicherung von Secrets überflüssig macht und eine bessere Sicherheit bietet.

## Fehlerbehebung
### Häufige Probleme:
1. **Authentifizierungsfehler:** Überprüfe, ob dein Secret `AZURE_CREDENTIALS` die vollständige JSON-Ausgabe enthält
2. **Berechtigungsfehler:** Stelle sicher, dass der Service Principal die erforderlichen Berechtigungen hat
3. **Namenskonflikte bei Ressourcen:** Die Namen von Storage-Konten müssen global eindeutig sein
4. **Zugriff auf das Abonnement:** Überprüfe, ob der Service Principal Zugriff auf das richtige Abonnement hat

### Nützliche Befehle zur Fehlersuche:

```bash
# Aktuellen Azure-Kontext überprüfen
az account show

# Service Principals auflisten
az ad sp list --display-name "github-actions-sp"

# Berechtigungen des Service Principals überprüfen
az role assignment list --assignee {service-principal-id}
```

## Zusätzliche Ressourcen

- [Dokumentation zu Azure Service Principal](https://docs.microsoft.com/en-us/azure/active-directory/develop/app-objects-and-service-principals)
- [Dokumentation zur azure/login Action](https://github.com/Azure/login)
- [Dokumentation zu GitHub Actions Secrets](https://docs.github.com/en/actions/security-guides/encrypted-secrets)
- [Azure CLI Referenz](https://docs.microsoft.com/en-us/cli/azure/)
