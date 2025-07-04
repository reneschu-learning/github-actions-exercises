# Lösung: Übung 11 – Azure Deployment mit OIDC

Dieses Verzeichnis enthält die Lösung für Übung 11, in der gezeigt wird, wie Azure-Ressourcen mit GitHub Actions und OpenID Connect (OIDC) bereitgestellt werden.

## Überblick
Die Lösung umfasst:
- Einen GitHub Actions Workflow, der sich mit OIDC authentifiziert
- Bereitstellung von Azure-Ressourcen (Resource Group, Storage Account, Container)
- Korrektes Secret-Management und Sicherheitspraktiken
- Fehlerbehandlung und Aufräumprozeduren

## Workflows in dieser Lösung
- `azure-deployment-oidc.yml`  
  Haupt-Workflow, der OIDC-Authentifizierung und Deployment demonstriert
- `azure-deployment-oidc-with-cleanup.yml`  
  Erweiterter Workflow mit Aufräum-Schritten zum Löschen der Ressourcen nach dem Deployment

## Wichtige Lernpunkte

### 1. OIDC-Authentifizierung
- Verwendet die Action `azure/login` mit OIDC
- Keine langfristigen Secrets nötig
- Zugriff mit kurzlebigen Tokens

### 2. Ressourcenbereitstellung
- Erstellt Ressourcen mit Azure CLI-Befehlen
- Setzt sinnvolle Tags für das Ressourcenmanagement
- Enthält Verifikationsschritte

### 3. Sicherheitsaspekte
- Keine sensiblen Informationen gespeichert
- Service Principal folgt dem Prinzip der minimalen Rechtevergabe
- Keine hartkodierten Zugangsdaten in Workflow-Dateien

## Vergleich mit Service Principal ID/Secret
| Feature | Service Principal (Übung 10) | OIDC |
|---------|------------------|-------------------|
| Setup-Komplexität | Einfach | Mittel |
| Secret-Management | Erforderlich | Nicht erforderlich |
| Sicherheit | Gut | Exzellent |
| Wartung | Regelmäßige Rotation | Minimal |
| Token-Lebensdauer | Lang | Kurz |
