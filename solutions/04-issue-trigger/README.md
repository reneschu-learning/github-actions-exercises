# Solution: Issue Trigger

This directory contains the solution for Exercise 4: Issue Trigger.

## Files
- `hello-world.yml` - The GitHub Actions workflow file with multiple triggers

## Key Features
- Multiple trigger types (manual and issues)
- Issue context access
- Safe handling of context and input data

## Triggers
- `workflow_dispatch` - Manual trigger with inputs
- `issues` (opened) - Automatic trigger when issues are opened

## Security Considerations
- Context and input data should be treated as untrusted (allowing for potential malicious content and script injection)
- Use environment variables to safely handle context and input data
- Avoid executing issue content directly as code

## Usage
1. Copy the workflow file to `.github/workflows/` in your repository
2. Commit and push the changes
3. Test both trigger methods:
   - Create a new issue to see automatic trigger

## What You'll Learn
- Multiple trigger configuration
- Issue event handling
- Security best practices
