# Übung 9: Vollständige CI/CD-Pipeline

## Lernziele
In dieser Übung lernst du:
- Wie du eine vollständige CI/CD-Pipeline mit mehreren Jobs zum Bauen, Testen und Deployen einer .NET-Anwendung erstellst
- Wie du beliebte GitHub Actions wie `actions/checkout` und `actions/setup-dotnet` verwendest
- Wie du eine .NET-Anwendung baust, testest und paketierst
- Wie du Artefakte nutzt, um Build-Ergebnisse zwischen Jobs zu übergeben
- Wie du korrekte Job-Abhängigkeiten und eine sinnvolle Workflow-Struktur implementierst
- Wie du Matrix-Strategien für Tests mit mehreren Versionen verwendest

## Hintergrund
Eine CI/CD (Continuous Integration/Continuous Deployment) Pipeline ist essenziell für moderne Softwareentwicklung. Sie automatisiert das Bauen, Testen und Deployen von Anwendungen, stellt die Codequalität sicher und ermöglicht schnelle, zuverlässige Releases.

Diese Übung vereint alles, was du bisher gelernt hast, um eine realistische CI/CD-Pipeline für eine .NET-Konsolenanwendung zu erstellen.

## Anleitung

### Teil 1: Untersuche die Beispielanwendung
1. Sieh dir die Beispiel-.NET-Konsolenanwendung im Verzeichnis `sample-app` an
2. Verstehe die Projektstruktur und Abhängigkeiten
3. Beachte das Testprojekt und dessen Aufbau

### Teil 2: Erstelle die CI/CD-Pipeline
Erstelle eine Workflow-Datei `.github/workflows/ci-cd-pipeline.yml` mit folgenden Jobs:

#### Build- und Test-Job
- Checke den Code mit [actions/checkout@v4](https://github.com/actions/checkout/tree/v4) aus
- Richte .NET mit [actions/setup-dotnet@v4](https://github.com/actions/setup-dotnet/tree/v4) ein
- Stelle Abhängigkeiten wieder her
- Baue die Anwendung
- Führe Unit-Tests aus
- Erzeuge Testberichte
- Lade Testergebnisse hoch
- Lade Build-Artefakte hoch

#### Package-Stage (abhängig von Build und Test)
- Lade Build-Artefakte herunter
- Paketisiere die Anwendung
- Lade paketierte Artefakte hoch

#### Deploy-Stage (abhängig von Package)
- Lade paketierte Artefakte herunter
- Simuliere das Deployment in verschiedene Environments
- Verwende Environments aus der vorherigen Übung

### Teil 3: Erweiterte Features
Füge diese fortgeschrittenen Features zu deiner Pipeline hinzu:

1. **Matrix-Strategie**: Teste gegen mehrere .NET-Versionen (6.0, 8.0)
2. **Bedingtes Deployment**: Deploy nur auf dem main-Branch
3. **Version Tagging**: Automatisches Taggen erfolgreicher Deployments
4. **Benachrichtigungen**: Füge Statusbenachrichtigungen für Jobs hinzu

### Teil 4: Trigger
Konfiguriere den Workflow so, dass er ausgelöst wird bei:
- Push auf den main-Branch
- Pull Requests auf den main-Branch
- Manuellem Trigger mit Environment-Auswahl

## Beispielanwendungsstruktur
Die Beispielanwendung enthält:
- Eine einfache .NET-Konsolenanwendung
- Unit-Tests mit xUnit
- Korrekte Projektdateikonfiguration
- Eine Solution-Datei, die alles zusammenführt

## Erwartetes Ergebnis
Nach Abschluss dieser Übung solltest du:
- Eine vollständige CI/CD-Pipeline haben, die eine .NET-Anwendung baut, testet und deployed
- Job-Abhängigkeiten und Artefaktmanagement verstehen
- Erfahrung mit Matrix-Strategien und bedingter Logik haben
- Ein funktionierendes Beispiel für Environment-basiertes Deployment besitzen

## Wichtige Konzepte
- **Continuous Integration**: Automatisches Bauen und Testen von Codeänderungen
- **Continuous Deployment**: Automatisches Deployen getesteten Codes in Environments
- **Artefakte**: Von Jobs erzeugte Dateien, die zwischen Jobs geteilt werden können
- **Job-Abhängigkeiten**: Mit `needs` die Ausführungsreihenfolge steuern
- **Matrix-Strategie**: Jobs mit unterschiedlichen Konfigurationen ausführen
- **Environment-Promotion**: Deployment durch verschiedene Environments (dev → staging → prod)

## Tipps
- Verwende aussagekräftige Job- und Schritt-Namen
- Halte Build-Artefakte klein, indem du nur notwendige Dateien einschließt
- Verwende angemessene Timeouts für verschiedene Stufen
- Nutze Caching für Abhängigkeiten, um Builds zu beschleunigen
- Behandle sowohl Erfolgs- als auch Fehlerfälle

## Nächste Schritte
In der nächsten Übung erweiterst du diese Pipeline um ein Deployment nach Azure mit Service Principal-Authentifizierung.
