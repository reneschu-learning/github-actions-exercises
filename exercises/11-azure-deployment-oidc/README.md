# Übung 11: Einfacher Workflow mit Azure Deployment (OIDC)
In dieser Übung erstellst du einen GitHub Actions Workflow, der Ressourcen in Azure mit OpenID Connect (OIDC) bereitstellt. Dieser Ansatz macht das Speichern von langfristigen Secrets im Repository überflüssig und bietet durch föderierte Identitäten erhöhte Sicherheit.

## Voraussetzungen
- **Abschluss von Übung 10 (Service Principal Authentifizierung)**
- Ein GitHub-Account und ein Repository für diese Übung
- Ein Azure-Abonnement mit Berechtigungen zum Erstellen von Ressourcen und Verwalten von föderierten Anmeldeinformationen
- Azure CLI lokal installiert (für die Setup-Schritte)

## Lernziele
Am Ende dieser Übung kannst du:
- Die Vorteile von OIDC gegenüber Service Principal Secrets verstehen
- Föderierte Identitätsanmeldeinformationen in Azure konfigurieren
- OIDC-Authentifizierung für GitHub Actions einrichten
- Azure-Ressourcen mit OIDC bereitstellen
- Die Sicherheitsvorteile von föderierter Authentifizierung verstehen

## Überblick
Diese Übung führt dich durch:
1. Verständnis von OIDC und föderierter Identität
2. Erstellen einer Azure AD-Anwendung und Konfigurieren von föderierten Anmeldeinformationen
3. Einrichten von Repository-Variablen und -Secrets für OIDC
4. Erstellen eines Workflows, der OIDC-Authentifizierung nutzt
5. Vergleich OIDC vs. Service Principal

## Was ist OIDC-Authentifizierung?
OpenID Connect (OIDC) ermöglicht es GitHub Actions, sich mit Azure über kurzlebige Tokens statt langfristiger Secrets zu authentifizieren. Das bedeutet:

- **Kein Secret-Speichern:** Keine Notwendigkeit, Service Principal-Secrets in GitHub zu speichern
- **Mehr Sicherheit:** Kurzlebige Tokens, die automatisch rotiert werden
- **Weniger Wartung:** Keine manuelle Rotation von Zugangsdaten
- **Bessere Nachvollziehbarkeit:** Detaillierte Authentifizierungsprotokolle

## Schritt 1: Azure AD-Anwendung und Service Principal erstellen (falls nicht in Übung 10 erledigt)

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
Erstelle einen Service Principal mit Contributor-Zugriff auf dein Abonnement:

```bash
az ad sp create-for-rbac --name "github-actions-sp" --role contributor --scopes /subscriptions/{subscription-id} --create-password false
```

**Hinweis:** Wenn mehrere Personen in demselben Entra ID-Mandanten an dieser Übung teilnehmen, solltest du möglicherweise einen eindeutigen Namen für deinen Service Principal verwenden, um Konflikte zu vermeiden. Du kannst deinen GitHub-Benutzernamen oder eine zufällige Zeichenfolge an den Namen anhängen.

Ersetze `{subscription-id}` durch deine tatsächliche Abonnement-ID. Du kannst deine Abonnement-ID finden, indem du folgendes ausführst:

```bash
az account show --query id --output tsv
```r \
  --scope /subscriptions/{subscription-id}
```

Die Ausgabe sieht so aus:
```json
{
  "appId": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",
  "displayName": "github-actions-sp",
  "password": null,
  "tenant": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
}
```

## Schritt 2: Föderierte Anmeldeinformationen konfigurieren
Föderierte Anmeldeinformationen erlauben der Azure AD-Anwendung, Tokens von GitHub Actions zu vertrauen. Die Vertrauensstellung ist eng mit deinem GitHub-Repository und Branch verknüpft. Mehr dazu in der [GitHub OIDC-Dokumentation](https://docs.github.com/en/actions/concepts/security/about-security-hardening-with-openid-connect#example-subject-claims).

### Föderierte Anmeldeinformationen für den main-Branch erstellen
Für diese Übung erstellen wir nur eine föderierte Anmeldeinformation für den Haupt-Branch. Führe den folgenden Befehl aus:

```bash
az ad app federated-credential create \
  --id {appId} \
  --parameters '{
    "name": "github-actions-main",
    "issuer": "https://token.actions.githubusercontent.com",
    "subject": "repo:{github-username}/{repository-name}:ref:refs/heads/main",
    "description": "GitHub Actions OIDC für den Haupt-Branch",
    "audiences": ["api://AzureADTokenExchange"]
  }'
```

## Schritt 3: Repository-Variablen konfigurieren
Denke daran, dass du mit OIDC keine Secrets in deinem Repository speichern musst. Stattdessen verwendest du Repository-Variablen, um die erforderlichen Informationen für den Workflow zu speichern. Gehe zu deinem Repository → Einstellungen → Secrets und Variablen → Aktionen → Registerkarte Variablen:

1. **Name:** `AZURE_CLIENT_ID`
   **Wert:** Die `appId` aus Schritt 1.3

2. **Name:** `AZURE_TENANT_ID`
   **Wert:** Die `tenant` aus Schritt 1.3

3. **Name:** `AZURE_SUBSCRIPTION_ID`
   **Wert:** Deine Azure-Abonnement-ID


## Schritt 4: Workflow erstellen
Erstelle eine Workflow-Datei `.github/workflows/azure-deployment-oidc.yml`, die OIDC-Authentifizierung verwendet und Ressourcen bereitstellt.

## Sicherheitshinweis
- Keine langfristigen Secrets im Repository
- Kurzlebige Tokens werden automatisch rotiert
- Zugriff kann granular über Azure und GitHub gesteuert werden

## Vergleich: OIDC vs. Service Principal
| Feature | Service Principal | OIDC |
|---------|------------------|------|
| Setup-Komplexität | Einfach | Mittel |
| Secret-Management | Erforderlich | Nicht erforderlich |
| Sicherheit | Gut | Exzellent |
| Wartung | Regelmäßige Rotation | Minimal |
| Token-Lebensdauer | Lang | Kurz |

## Nächste Schritte
Nach dieser Übung kannst du deine Workflows noch sicherer und wartungsärmer gestalten!
