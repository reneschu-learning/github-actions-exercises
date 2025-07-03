# Exercise 2: Accessing Context

## Objective
Learn how to access GitHub context information in your workflows and display information about the actor who triggered the workflow.

## Instructions

1. **Modify the Hello World workflow**: Starting from Exercise 1, modify your workflow to:
   - Print "Hello, World!" as before
   - Add a `run-name` that shows who triggered the workflow
   - Print the username of the person who triggered the workflow
   - Print the repository name
   - Print the current branch or reference

2. **Use GitHub context**: Use the `github` context object to access:
   - `github.actor` - the username of the person who triggered the workflow
   - `github.repository` - the repository name in format "owner/repo"
   - `github.ref` - the git reference (branch/tag) that triggered the workflow

3. **Test the workflow**: Trigger the workflow manually and observe the context information

## Key Concepts
- GitHub context object (`github`)
- Accessing context variables using `${{ github.property }}`
- Common context properties: `actor`, `repository`, `ref`

## Expected Output
```
Hello, World!
Triggered by: [your-username]
Repository: [owner/repo-name]
Reference: refs/heads/main
```

## Hints
- Context variables are accessed using the `${{ }}` syntax
- You can use multiple `echo` commands or combine them in a single step
- The `github` context is automatically available in all workflows

## Solution
If you get stuck, check the [solution](../../solutions/02-accessing-context/) directory for a working example.
