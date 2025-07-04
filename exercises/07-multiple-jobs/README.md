# Übung 7: Mehrere Jobs

## Ziel
Lerne, wie du Workflows mit mehreren Jobs erstellst, Job-Abhängigkeiten verstehst, parallele vs. sequentielle Ausführung steuerst und Bedingungen auf Job-Ebene verwendest.

## Anleitung

1. **Erstelle einen Multi-Job-Workflow**: Entwirf einen Workflow, der eine CI/CD-Pipeline simuliert mit:
   - **Setup-Job**: Validiert die Umgebung und bereitet andere Jobs vor  
     Dieser Job läuft auf `ubuntu-latest` und soll:
     - Die Node.js- und npm-Versionen ausgeben
     - Ein `VERSION`-Output erzeugen, z.B. `1.0.<workflow run number>`
     - Ein `deploy`-Output erzeugen, das auf `true` steht, wenn der aktuelle Branch `main` ist, sonst `false`
   - **Test-Jobs**: Mehrere Jobs, die parallel laufen können (Tests, Linting)  
     - Der Test-Job läuft auf `ubuntu-latest` und simuliert Tests (gibt eine Nachricht aus und schläft ein paar Sekunden)
     - Der Linting-Job ist ein Matrix-Job, der auf `ubuntu-latest` und `windows-latest` läuft, simuliert Linting (gibt eine Nachricht aus und schläft)
   - **Build-Job**: Baut die Anwendung (hängt von Tests ab)  
     Läuft auf `ubuntu-latest`, erstellt eine Artefakt-Datei (z.B. mit touch), gibt den Artefaktnamen als Output aus und lädt das Artefakt hoch
   - **Deploy-Job**: Deployt die Anwendung (hängt vom Build ab)  
     Läuft auf `ubuntu-latest` und läuft nur, wenn das `deploy`-Output vom Setup-Job `true` ist. Lädt das Artefakt herunter, listet die Datei und simuliert das Deployment
   - **Cleanup-Job**: Läuft immer am Ende, unabhängig vom Ergebnis der vorherigen Jobs  
     Läuft auf `ubuntu-latest`, gibt eine Nachricht und die Ergebnisse der vorherigen Jobs aus

2. **Konfiguriere Job-Abhängigkeiten**:
   - Test-Jobs hängen vom Setup-Job ab
   - Build-Job hängt von allen Test-Jobs ab
   - Deploy-Job hängt vom Build-Job ab
   - Cleanup-Job läuft immer am Ende

3. **Füge parallele Ausführung hinzu**:
   - Test-Jobs laufen parallel
   - Zeige verschiedene Betriebssysteme für einige Jobs
   - Zeige Job-Outputs und Artefakte

4. **Behandle Job-Fehler**:
   - Cleanup läuft immer, auch bei Fehlern in anderen Jobs
   - Zeige bedingtes Deployment basierend auf Testergebnissen
   - Verwende Job-Outputs, um Daten zwischen Jobs zu übergeben

## Wichtige Konzepte
- Mehrere Job-Definitionen in einem Workflow
- Job-Abhängigkeiten mit `needs:`
- Parallele vs. sequentielle Ausführung
- Job-Outputs mit `outputs:`
- Job-Matrix für mehrere OS/Versionen
- Bedingte Job-Ausführung
- `always()`-Funktion für Job-Status

## Erwartetes Verhalten
```
Setup Job (läuft zuerst)
      ↓
┌── Tests ──┐
|           | (laufen parallel)
└── Linting ┘
      ↓
Build Job (wartet auf alle Tests)
      ↓
Deploy Job (wartet auf Build)
      ↓
Cleanup Job (läuft immer)
```

## Erweiterte Features
- Job-Matrix für mehrere Umgebungen
- Artefakte zwischen Jobs hoch- und herunterladen
- Setzen und Verwenden von Job-Outputs
- Bedingtes Deployment je nach Branch

## Hinweise
- Verwende `needs: [ job1, job2 ]` für mehrere Abhängigkeiten
- Verwende `strategy.matrix` für mehrere Konfigurationen
- Job-Outputs: `outputs.key: ${{ steps.step-id.outputs.value }}`
- Zugriff auf Job-Outputs: `needs.job-name.outputs.output-name`
- Verwende `if: always()` für Cleanup-Jobs
- Verschiedene `runs-on`-Werte für OS-Vielfalt
- Nutze [`actions/upload-artifact@v4`](https://github.com/actions/upload-artifact/tree/v4) und [`actions/download-artifact@v4`](https://github.com/actions/download-artifact/tree/v4) für Artefakte

## Workflow ausführen
- Starte den Workflow auf dem `main`-Branch, um das Deployment zu sehen
- Erstelle einen neuen Branch und starte den Workflow, um zu sehen, dass das Deployment übersprungen wird
- Fehler simulieren? – Füge Inputs (`fail-setup`, `fail-build`, `fail-tests`, `fail-linting`, `fail-deploy`; Typ: `boolean`, Standard: `false`) hinzu und lasse Jobs gezielt fehlschlagen, um das Verhalten zu testen
  - Was passiert, wenn das Linting fehlschlägt? – Frage deinen Dozenten!

## Lösung
Wenn du nicht weiterkommst, sieh im [solution](../../solutions/07-multiple-jobs/) Verzeichnis nach funktionierenden Beispielen nach.
