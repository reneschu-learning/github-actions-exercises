# Exercise 6: Using Workflow Token

## Objective
Learn how to use the automatically generated workflow token (`GITHUB_TOKEN`) to authenticate API requests and interact with your repository using the GitHub CLI.

## Instructions

1. **Add GitHub CLI usage**: Modify your workflow from Exercise 5 to include steps that use the GitHub CLI (`gh`):
   - Add a step that creates a comment on an issue when the workflow is triggered by an issue event
   - Add a step that retrieves repository information when manually triggered
   - Add a step that lists recent workflow runs when triggered by schedule

2. **Token Authentication**: Learn to use the `GITHUB_TOKEN`:
   - Use the token to authenticate GitHub CLI commands
   - Understand the default permissions of the workflow token
   - Practice reading repository data and writing comments

3. **Security Considerations**: 
   - Understand what permissions the workflow token has by default
   - Learn when and why you might need to request additional permissions

## Key Concepts
- `GITHUB_TOKEN` secret and its automatic creation
- GitHub CLI (`gh`) tool and its integration with workflows
- Token permissions and security boundaries
- API authentication in workflows
- Conditional execution based on trigger types

## Expected Output

**When manually triggered:**
```
Hello Alice!
Triggered by: [your-username]
Repository: [owner/repo-name]
Reference: refs/heads/main

Repository Information:
Name: my-repo
Owner: my-username  
Description: A sample repository
Private: false
Default branch: main
```

**When triggered by issue:**
```
New issue opened!
Issue #5: Bug in login functionality
Body: When I try to log in with my credentials...
Opened by: user123
Issue URL: https://github.com/owner/repo/issues/5

✓ Comment added to issue #5
```

**When triggered by schedule:**
```
Daily status check - All systems operational
Current time: 2024-01-15T09:00:00Z

Recent workflow runs:
✓ Hello World with Conditions - main (completed)
✓ Hello World with Conditions - main (completed)  
⏳ Hello World with Conditions - main (in_progress)
```

## GitHub CLI Commands to Use
- `gh repo view` - Get repository information
- `gh issue comment` - Add comment to an issue
- `gh run list` - List workflow runs

## Security Notes
- The `GITHUB_TOKEN` is automatically available in all workflow runs
- It has read permissions to the repository content and packages by default
- It cannot access other repositories or perform admin actions
- Token permissions can be extended using the `permissions` key in workflows

## Hints
- The GitHub CLI is pre-installed on GitHub-hosted runners
- Use `gh auth status` to verify authentication
- Environment variables can be passed to `gh` commands
- The token is available as `${{ secrets.GITHUB_TOKEN }}`
- Use conditional steps based on `github.event_name` to control when each step runs
