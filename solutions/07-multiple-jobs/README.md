# Lösung: Mehrere Jobs

Dieses Verzeichnis enthält die Lösung für Übung 7: Mehrere Jobs.

## Dateien
- `multi-job-pipeline.yml` – Beispiel für einen Multi-Job CI/CD-Workflow
- `multi-job-pipeline-with-failures.yml` – Beispiel für Multi-Job-Workflow mit Fehler-Simulation

## Wichtige Merkmale
- Sechs-Job CI/CD-Pipeline-Simulation
- Job-Abhängigkeiten und Reihenfolge
- Parallele Testausführung
- Job-Outputs und Kommunikation zwischen Jobs
- Bedingtes Deployment
- Matrix-Strategie für Multi-OS-Tests
- Cleanup-Job, der immer läuft

## Job-Ablauf
```
Setup → Tests (parallel) → Build → Deploy → Cleanup
        ├─ Unit Tests
        └─ Linting (multi-OS)
```

## Job-Abhängigkeiten
- Tests hängen von Setup ab
- Build hängt von allen Tests ab
- Deploy hängt von Setup + Build ab
- Cleanup läuft immer (hängt von allen ab)

## Erweiterte Features
- Job-Outputs (`VERSION`, `deploy`)
- Matrix-Strategie für OS-Tests
- Bedingtes Deployment je nach Branch
- Umfassendes Status-Reporting

## Verwendung
1. Kopiere die Workflow-Datei nach `.github/workflows/` in deinem Repository
2. Committe und pushe die Änderungen
3. Starte den Workflow
4. Beobachte die Ausführungsreihenfolge und parallele Verarbeitung

## Was du lernst
- Multi-Job-Workflow-Design
- Job-Abhängigkeiten mit `needs:`
- Parallele vs. sequentielle Ausführung
- Job-Outputs und Kommunikation
- Matrix-Strategien
- Bedingte Job-Ausführung
- Produktionsnahe Deployment-Muster
