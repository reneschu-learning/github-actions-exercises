# Übung 2: Zugriff auf Kontext

## Ziel
Lerne, wie du GitHub-Kontextinformationen in deinen Workflows abrufst und Informationen über den Akteur anzeigst, der den Workflow ausgelöst hat.

## Anleitung

1. **Modifiziere den Hello World Workflow**: Baue auf Übung 1 auf und passe deinen Workflow an, sodass:
   - „Hello, World!“ wie zuvor ausgegeben wird
   - Ein `run-name` angezeigt wird, der zeigt, wer den Workflow ausgelöst hat
   - Der Benutzername der Person ausgegeben wird, die den Workflow ausgelöst hat
   - Der Name des Repositories ausgegeben wird
   - Der aktuelle Branch oder die Referenz ausgegeben wird

2. **Verwende GitHub-Kontext**: Nutze das `github` Kontextobjekt, um auf folgende Werte zuzugreifen:
   - `github.actor` – der Benutzername der Person, die den Workflow ausgelöst hat
   - `github.repository` – der Repository-Name im Format „owner/repo“
   - `github.ref` – die Git-Referenz (Branch/Tag), die den Workflow ausgelöst hat

3. **Teste den Workflow**: Löse den Workflow manuell aus und beobachte die Kontextinformationen

## Wichtige Konzepte
- GitHub Kontextobjekt (`github`)
- Zugriff auf Kontextvariablen mit `${{ github.property }}`
- Häufige Kontext-Properties: `actor`, `repository`, `ref`

## Erwartete Ausgabe
```
Hello, World!
Triggered by: [dein-benutzername]
Repository: [owner/repo-name]
Reference: refs/heads/main
```

## Hinweise
- Kontextvariablen werden mit der `${{ }}`-Syntax abgerufen
- Du kannst mehrere `echo`-Befehle verwenden oder sie in einem Schritt kombinieren
- Das `github` Kontextobjekt ist in allen Workflows automatisch verfügbar

## Lösung
Wenn du nicht weiterkommst, sieh im [solution](../../solutions/02-accessing-context/) Verzeichnis nach einem funktionierenden Beispiel nach.
