# Übung 3: Trigger-Inputs

## Ziel
Lerne, wie du Workflows erstellst, die beim manuellen Auslösen Eingaben akzeptieren und so ein dynamisches Verhalten basierend auf Benutzereingaben ermöglichen.

## Anleitung

1. **Füge Workflow-Inputs hinzu**: Erweitere deinen Workflow aus Übung 2, sodass er Eingaben akzeptiert:
   - Füge ein `name`-Input (erforderlich) mit der Beschreibung „Dein Name für eine personalisierte Begrüßung“ hinzu
   - Füge ein `greeting`-Input (optional) mit der Beschreibung „Benutzerdefinierte Begrüßungsnachricht“ und dem Standardwert „Hello“ hinzu

2. **Verwende Inputs im Workflow**: Passe den Workflow an, sodass:
   - Die Inputs `greeting` und `name` für eine personalisierte Nachricht verwendet werden
   - Die Kontextinformationen aus Übung 2 weiterhin angezeigt werden

3. **Teste mit verschiedenen Eingaben**: Probiere den Workflow aus mit:
   - Nur dem erforderlichen `name`-Input
   - Sowohl `name`- als auch `greeting`-Input
   - Verschiedenen Begrüßungsnachrichten

## Wichtige Konzepte
- Workflow-Inputs mit `workflow_dispatch.inputs`
- Input-Typen, Beschreibungen und Standardwerte
- Erforderliche vs. optionale Inputs
- Zugriff auf Inputs mit `github.event.inputs.input_name`

## Erwartete Ausgabe
```
Hello Alice!
Triggered by: [dein-benutzername]
Repository: [owner/repo-name]
Reference: refs/heads/main
```

Oder mit benutzerdefinierter Begrüßung:
```
Good morning Alice!
Triggered by: [dein-benutzername]
Repository: [owner/repo-name]
Reference: refs/heads/main
```

## Hinweise
- Definiere Inputs unter `on.workflow_dispatch.inputs`
- Jeder Input kann die Eigenschaften `description`, `required`, `default`, `type` haben
- Auf Inputs greifst du mit `${{ github.event.inputs.input_name }}` zu
- Der `type` kann `string`, `boolean`, `choice` oder `environment` sein

## Sicherheitshinweis
Dieser Workflow ist anfällig für Skript-Injektion, da die Eingaben direkt in der Ausgabe verwendet werden. Was passiert, wenn du das `name`-Input auf `"; ls -Rla ~; echo "` setzt? 😲 Probiere es aus und beobachte das Verhalten. Was passiert bei `"; rm -rf /; echo"`? 🫣 Wir beheben dieses Sicherheitsproblem in der nächsten Übung.

## Lösung
Wenn du nicht weiterkommst, sieh im [solution](../../solutions/03-trigger-inputs/) Verzeichnis nach einem funktionierenden Beispiel nach.
