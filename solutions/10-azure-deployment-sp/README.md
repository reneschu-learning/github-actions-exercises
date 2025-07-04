# Lösung: Übung 10 – Azure Deployment mit Service Principal

Dieses Verzeichnis enthält die Lösung für Übung 10, in der gezeigt wird, wie Azure-Ressourcen mit GitHub Actions und Service Principal-Authentifizierung bereitgestellt werden.

## Überblick

Die Lösung umfasst:
- Einen GitHub Actions Workflow, der sich mit einem Service Principal authentifiziert
- Bereitstellung von Azure-Ressourcen (Resource Group, Storage Account, Container)
- Korrektes Secret-Management und Sicherheitspraktiken

## Workflows in dieser Lösung
- `azure-deployment-sp.yml`  
  Haupt-Workflow, der Service Principal-Authentifizierung und Deployment demonstriert
- `azure-deployment-sp-with-cleanup.yml`  
  Erweiterter Workflow mit Aufräum-Schritten zum Löschen der Ressourcen nach dem Deployment

## Wichtige Lernpunkte

### 1. Service Principal Authentifizierung
- Verwendet die Action `azure/login` mit gespeicherten Zugangsdaten
- Benötigt das Secret `AZURE_CREDENTIALS` mit vollständiger JSON-Konfiguration
- Bietet sofortigen Zugriff, erfordert aber Secret-Management

### 2. Ressourcenbereitstellung
- Erstellt Ressourcen mit Azure CLI-Befehlen
- Setzt sinnvolle Tags für das Ressourcenmanagement
- Enthält Verifikationsschritte

### 3. Sicherheitsaspekte
- Alle sensiblen Informationen werden als GitHub Secrets gespeichert
- Service Principal folgt dem Prinzip der minimalen Rechtevergabe
- Keine hartkodierten Zugangsdaten in Workflow-Dateien

## Vergleich mit OIDC
| Feature | Service Principal | OIDC (Übung 11) |
|---------|------------------|-------------------|
| Setup-Komplexität | Einfach | Mittel |
| Secret-Management | Erforderlich | Nicht erforderlich |
| Sicherheit | Gut | Exzellent |
| Wartung | Regelmäßige Rotation | Minimal |
| Token-Lebensdauer | Lang | Kurz |

## Nächste Schritte
Nach dieser Übung kannst du mit Übung 11 fortfahren, um OIDC-Authentifizierung kennenzulernen, die noch mehr Sicherheit bietet und keine gespeicherten Secrets benötigt.
