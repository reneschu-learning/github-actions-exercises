# Exercise 4: Issue Trigger

## Objective
Learn how to trigger workflows based on GitHub issues and understand security considerations when using context and inputs.

## Instructions

1. **Add issue trigger**: Modify your workflow from Exercise 3 to also trigger when:
   - An issue is opened in the repository
   - Keep the manual trigger with inputs from Exercise 3
     - Make the `name` input optional and default to "World"
   - Print the issue title
   - Print the issue body
   - Print the issue number and URL
   - Print who opened the issue

2. **Create a new issue**: After modifying the workflow, create a new issue in the repository to test the issue trigger.

## Key Concepts
- Multiple trigger types in a single workflow
- Issue events and their types (`opened`, `closed`, `edited`, etc.)
- Issue context: `github.event.issue`
- Security considerations with issue content

## Expected Output

**When triggered by issue:**
```
 !
Triggered by: [your-username]
Repository: [owner/repo-name]
Reference: refs/heads/main

New issue opened!
Issue #5: Bug in login functionality
Body: When I try to log in with my credentials...
Opened by: user123
Issue URL: https://github.com/owner/repo/issues/5
```

**When manually triggered (greeting=Welcome, name=Alice):**
```
Welcome Alice!
Triggered by: [your-username]
Repository: [owner/repo-name]
Reference: refs/heads/main

New issue opened!
Issue #:
Body:
Opened by:
Issue URL:
```

As you can see, depending on the triggering event, either the issue information or the greeting is missing. We will fix this in the next exercise.

## Security Considerations
- Issue titles and bodies can contain malicious content
- Be careful when using issue content in scripts
- Consider sanitizing or limiting how issue content is used
- Avoid directly executing issue content as code

## Hints
- Use multiple triggers: `on: [workflow_dispatch, issues]`
- Specify issue types: `on.issues.types: [opened]`
- Access issue data: `github.event.issue.title`, `github.event.issue.body`, etc.
- Use environment variables or other means of sanitization when referencing potentially unsafe content

## Solution
If you get stuck, check the [solution](../../solutions/04-issue-trigger/) directory for a working example.
