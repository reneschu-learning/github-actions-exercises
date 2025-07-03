# Solution: Using Workflow Token

This directory contains the solution for Exercise 6: Using Workflow Token.

## Files
- `hello-world.yml` - The GitHub Actions workflow file with GitHub CLI integration

## Key Features
- Utilizes `GITHUB_TOKEN` for authentication
- GitHub CLI (`gh`) integration for API interactions
- Repository information retrieval
- Issue commenting functionality
- Workflow run listing
- Conditional execution based on trigger types

## Triggers
- `workflow_dispatch` - Manual trigger with inputs
- `issues` (opened) - Issue creation trigger  
- `schedule` - Daily at 9:00 AM UTC

## GitHub CLI Commands Used
- `gh auth status` - Verify GitHub CLI authentication
- `gh repo view` - Display repository information
- `gh issue comment` - Add comments to issues
- `gh run list` - List recent workflow runs

## Token Permissions
The workflow extends the default permissions of the `GITHUB_TOKEN` and requires:
- Read access to repository contents
- Write access to issues
- Read access to actions

## Advanced Concepts
- Environment variable usage with GitHub CLI
- Token authentication patterns
- Conditional step execution
- Error handling with CLI commands
- JSON output parsing

## Usage
1. Copy the workflow file to `.github/workflows/` in your repository
2. Commit and push the changes
3. Test all three trigger types:
   - Manual execution to see repository info
   - Create an issue to see automated commenting
   - Wait for scheduled run to see workflow history

## Security Best Practices
- Always use the provided `GITHUB_TOKEN` instead of personal access tokens when possible
- Understand the principle of least privilege
- Be cautious when using tokens in public repositories
- Consider using `permissions` key to extend/restrict token scope explicitly if needed
