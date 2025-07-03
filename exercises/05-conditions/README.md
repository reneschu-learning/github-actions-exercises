# Exercise 5: Conditions

## Objective
Learn how to use conditions to control step execution, and handle multiple trigger types gracefully.

## Instructions

1. **Add cron trigger**: Add a scheduled trigger to your workflow from Exercise 4:
   - Add a cron schedule that runs every day at 9:00 AM UTC
   - Keep existing manual and issue triggers

2. **Improve conditional logic**: Enhance the workflow to handle all three trigger types:
   - Manual trigger: Show personalized greeting
   - Issue trigger: Show issue information  
   - Schedule trigger: Show a daily status message
   - The run name should either show the issue number, `Cron` (when triggered by schedule), or the actor (when manually triggered):
     - Issue trigger: `Issue #<issue_number> triggered this workflow`
     - Schedule trigger: `Cron triggered this workflow`
     - Manual trigger: `Alice triggered this workflow`

## Key Concepts
- Cron scheduling with `schedule.cron`
- Step-level conditions with `if:`
- Complex conditional expressions
- Default values and null checking
- Multiple trigger handling strategies

## Expected Output

**When manually triggered:**
```
Hello Alice!
Triggered by: [your-username]
Repository: [owner/repo-name]
Reference: refs/heads/main
```

**When triggered by issue:**
```
New issue opened!
Issue #5: Bug in login functionality
Body: When I try to log in with my credentials...
Opened by: user123
Issue URL: https://github.com/owner/repo/issues/5
```

**When triggered by schedule:**
```
Daily status check - All systems operational
Current time: 2024-01-15T09:00:00Z
```

## Advanced Concepts
- Using `format()` function
- Combining conditions with `&&` and `||`
- Checking for null/empty values

## Hints
- Use `'0 9 * * *'` for daily 9 AM UTC cron trigger (schedule triggers are **always** UTC)
- Check event type: check `github.event_name` equals specific event or `github.event.<event_type>` is null
- `format()` can help create dynamic run names (syntax: `format('text {0} {1}', variable0, variable1)`)
- To escape the hash symbol in the run name, enclose the full expression in single quotes and use double single quotes when you need to include string content:
  ```yaml
  run-name: '${{ format(''Issue #{0}'', github.event.issue.number) }}'
  ```

## Solution
If you get stuck, check the [solution](../../solutions/05-conditions/) directory for a working example.
