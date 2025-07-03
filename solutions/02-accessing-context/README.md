# Solution: Accessing Context

This directory contains the solution for Exercise 2: Accessing Context.

## Files
- `hello-world.yml` - The GitHub Actions workflow file with context access

## Key Features
- Manual trigger using `workflow_dispatch`
- Accesses GitHub context information
- Displays actor, repository, and reference information
- Uses multi-line run commands

## Context Variables Used
- `github.actor` - Username who triggered the workflow
- `github.repository` - Repository name in owner/repo format
- `github.ref` - Git reference (branch/tag)

## Usage
1. Copy the workflow file to `.github/workflows/` in your repository
2. Commit and push the changes
3. Manually trigger the workflow
4. Observe the context information in the logs

## What You'll Learn
- GitHub context object
- Accessing context variables with `${{ }}`
- Multi-line shell commands with `|`
- Common context properties
