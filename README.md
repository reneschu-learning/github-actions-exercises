# GitHub Actions Übungs-Repository
Dieses Repository enthält eine Reihe von Übungen, mit denen du GitHub Actions lernen und praktisch anwenden kannst. Jede Übung befindet sich in einem eigenen Verzeichnis im [exercises](./exercises/)-Ordner und enthält eine `README.md` mit Anleitung und Kontext. Einige Übungen bauen aufeinander auf, daher empfiehlt es sich, sie der Reihe nach zu bearbeiten. Im [solutions](./solutions/)-Verzeichnis findest du Beispiel-Lösungen zu jeder Übung. Du kannst diese Lösungen nutzen, wenn du nicht weiterkommst oder deine Lösung vergleichen möchtest.

## Voraussetzungen
Um die Übungen in diesem Repository zu bearbeiten, solltest du Folgendes mitbringen:
- Ein GitHub-Account: Du benötigst einen Account, um Repositories zu erstellen und Workflows auszuführen.
  - Ein persönlicher Account ist empfehlenswert, da du damit weniger Einschränkungen durch Organisationen hast.
- Grundkenntnisse in Git: Befehle wie `clone`, `commit`, `push` und `pull` solltest du kennen.
- Grundverständnis von YAML: GitHub Actions Workflows werden in YAML definiert, daher solltest du die Syntax verstehen.
- Vertrautheit mit GitHub: Du solltest dich auf GitHub zurechtfinden, Repositories anlegen und Issues sowie Pull Requests verwalten können.
- Ein Code-Editor: Du kannst jeden Editor deiner Wahl nutzen, um Workflow-Dateien zu bearbeiten und die Anleitungen zu lesen.
- Optional: Grundkenntnisse im Umgang mit der Kommandozeile, da manche Übungen Terminalbefehle enthalten.

## Einstieg
So startest du mit den Übungen:

1. **Repository klonen**: Klone das Repository auf deinen Rechner:
   ```
   git clone https://github.com/reneschu-learning/github-actions-exercises.git
   ```

2. **In ein Übungs-Verzeichnis wechseln**: Jede Übung ist in einem eigenen Ordner. Wechsle in das gewünschte Verzeichnis:
   ```
   cd github-actions-exercises/01-hello-world
   ```

3. **Anleitung befolgen**: Öffne die `README.md` im Übungsordner und folge den Schritten.

# Inhaltsverzeichnis
## Grundlagen-Übungen
- [Übung 1: Hello World](./exercises/01-hello-world/README.md) ([Lösung](./solutions/01-hello-world/))  
  Einstieg in GitHub Actions mit einem einfachen Workflow, der "Hello, World!" ausgibt. Einführung in die Grundstruktur einer Workflow-Datei und den manuellen Trigger.
- [Übung 2: Zugriff auf Kontext](./exercises/02-accessing-context/README.md) ([Lösung](./solutions/02-accessing-context/))  
  Hier lernst du, wie du Kontextinformationen in Workflows nutzt. Du erweiterst den "Hello, World!"-Workflow aus Übung 1, um Informationen über den Auslöser (actor) anzuzeigen.
- [Übung 3: Trigger-Inputs](./exercises/03-trigger-inputs/README.md) ([Lösung](./solutions/03-trigger-inputs/))
  Du lernst, wie du einen Workflow erstellst, der beim manuellen Auslösen Eingaben akzeptiert. Der "Hello, World!"-Workflow aus Übung 2 wird erweitert, um einen Namen als Input zu akzeptieren und eine personalisierte Begrüßung auszugeben.
- [Übung 4: Issue-Trigger](./exercises/04-issue-trigger/README.md) ([Lösung](./solutions/04-issue-trigger/))
  Hier lernst du, wie du Workflows durch GitHub Issues auslöst. Der Workflow aus Übung 3 wird erweitert, sodass er auch bei neuen Issues läuft und Titel sowie Body des Issues ausgibt. Außerdem werden Sicherheitsaspekte beim Umgang mit Kontext und Inputs behandelt.
- [Übung 5: Bedingungen](./exercises/05-conditions/README.md) ([Lösung](./solutions/05-conditions/))
  In dieser Übung lernst du, Bedingungen zu nutzen, um die Ausführung von Schritten zu steuern. Der Workflow aus Übung 4 wird so angepasst, dass er nicht fehlschlägt, wenn er nicht durch ein Issue ausgelöst wird. Außerdem wird ein weiterer Trigger (cron) hinzugefügt.
- [Übung 6: Verwendung des Workflow-Tokens](./exercises/06-workflow-token/README.md) ([Lösung](./solutions/06-workflow-token/))
  Einführung in das Workflow-Token, das für jeden Workflow-Lauf automatisch erstellt wird. Du lernst, wie du das Token für API-Requests und Aktionen im Namen des Workflows nutzt. Außerdem wird die [GitHub CLI](https://cli.github.com/) (`gh`) vorgestellt.
- [Übung 7: Mehrere Jobs](./exercises/07-multiple-jobs/README.md) ([Lösung](./solutions/07-multiple-jobs/))
  Einführung in Workflows mit mehreren Jobs. Du lernst, wie man Jobs parallel ausführt, Abhängigkeiten setzt und Bedingungen auf Job-Ebene nutzt. Außerdem werden Matrix-Strategien, Job-Outputs und Artefakte behandelt.
- [Übung 8: Environments, Variablen und Secrets](./exercises/08-environments-variables-secrets/README.md) ([Lösung](./solutions/08-environments-variables-secrets/))
  Hier lernst du, wie du Environments, Variablen und Secrets in Workflows verwendest. Du erstellst einen Workflow, der ein Environment zur Steuerung des Zugriffs nutzt und Secrets für sensible Daten verwendet. Außerdem lernst du, wie du Variablen für wiederverwendbare Werte einsetzt.

## Fortgeschrittene Übungen
- [Übung 9: Vollständige CI/CD-Pipeline](./exercises/09-full-ci-cd-pipeline/README.md) ([Lösung](./solutions/09-full-ci-cd-pipeline/))
  Hier kombinierst du alles Gelernte zu einer vollständigen CI/CD-Pipeline. Du erstellst einen Workflow, der eine Beispielanwendung baut, testet und deployed. Außerdem lernst du neue Trigger (`push`, `pull_request`) und Actions wie `actions/checkout` oder `actions/setup-dotnet` kennen. Die Beispielanwendung findest du im [sample-app](./exercises/09-full-ci-cd-pipeline/sample-app/)-Verzeichnis.
- [Übung 10: Einfacher Workflow mit Azure Deployment (Service Principal)](./exercises/10-azure-deployment-sp/README.md) ([Lösung](./solutions/10-azure-deployment-sp/))
  Du erstellst einen einfachen Workflow für das Deployment von Ressourcen nach Azure mit Service Principal-Authentifizierung. Du lernst, wie man einen Service Principal erstellt, ihn im Workflow konfiguriert und Ressourcen (Resource Group, Storage Account, Storage Container) bereitstellt. Die Action `azure/login` wird vorgestellt.
- [Übung 11: Einfacher Workflow mit Azure Deployment (OIDC)](./exercises/11-azure-deployment-oidc/README.md) ([Lösung](./solutions/11-azure-deployment-oidc/))
  Aufbauend auf der vorherigen Übung nutzt du OIDC-Authentifizierung für das Azure-Deployment. Du lernst, wie man föderierte Anmeldeinformationen in Azure konfiguriert und die Action `azure/login` mit OIDC verwendet – ganz ohne gespeicherte Secrets.

## Experten-Übungen
- [Übung 12: Wiederverwendbare Workflows](./exercises/12-reusable-workflows/README.md) ([Lösung](./solutions/12-reusable-workflows/))
  Du lernst, wie du wiederverwendbare Workflows erstellst, die von anderen Workflows aufgerufen werden können. Die Pipeline aus Übung 9 wird refaktoriert, um Teile davon in einen wiederverwendbaren Workflow auszulagern.
- [Übung 13: Eigene Composite Actions](./exercises/13-custom-composite-actions/README.md) ([Lösung](./solutions/13-custom-composite-actions/))
  Einführung in eigene Composite Actions, mit denen du Teile deiner Workflows wiederverwendbar machen kannst, ohne zusätzliche Jobs zu erzeugen. Du erstellst eine Composite Action, die den Tagging-Schritt aus dem wiederverwendbaren Workflow von Übung 12 kapselt. Du lernst, wie man Inputs und Outputs in Composite Actions nutzt.
- [Übung 14: Zugriff auf externe Repositories](./exercises/14-accessing-external-repositories/README.md) ([Lösung](./solutions/14-accessing-external-repositories/))
  Hier lernst du, wie du mit GitHub Apps in Workflows auf externe Repositories zugreifst. Du erstellst eine GitHub App mit privatem Schlüssel, installierst sie in einer Organisation, speicherst den Schlüssel als Secret und verwendest die Action `actions/create-github-app-token@v1`, um Tokens für den Zugriff auf externe Repositories zu generieren. Du erstellst einen Workflow, der mit der App Issues in anderen Repositories anlegt.

# Mitmachen
Wenn du zu diesem Repository beitragen möchtest, folge diesen Schritten:

1. **Repository forken**: Klicke oben rechts auf "Fork" auf der GitHub-Seite.

2. **Neuen Branch anlegen**:
   ```
   git checkout -b mein-feature-branch
   ```

3. **Änderungen vornehmen**: Passe Code oder Dokumentation an.

4. **Änderungen committen**:
   ```
   git commit -m "Mein Feature hinzugefügt"
   ```

5. **Änderungen pushen**:
   ```
   git push origin mein-feature-branch
   ```

6. **Pull Request erstellen**: Erstelle im Original-Repository einen Pull Request von deinem Fork.

## Lizenz
Dieses Repository steht unter der MIT-Lizenz. Siehe [LICENSE](LICENSE) für Details.