# Solution: Conditions

This directory contains the solution for Exercise 5: Conditions.

## Files
- `hello-world.yml` - The GitHub Actions workflow file with advanced conditions

## Key Features
- Three trigger types: manual, issues, and scheduled
- Step-level conditional execution
- Complex conditional expressions for run names
- Safe handling of context and input data

## Triggers
- `workflow_dispatch` - Manual trigger with inputs
- `issues` (opened) - Issue creation trigger
- `schedule` - Daily at 9:00 AM UTC

## Advanced Concepts
- Step-level conditions with `if:`
- Event type detection
- `format()` function for dynamic run name

## Usage
1. Copy the workflow file to `.github/workflows/` in your repository
2. Commit and push the changes
3. Test all three trigger types:
   - Manual execution
   - Create an issue
   - Wait for scheduled run (or modify cron for testing)

## What You'll Learn
- Complex conditional logic
- Step-level conditions
- Cron scheduling syntax
- Event type handling
