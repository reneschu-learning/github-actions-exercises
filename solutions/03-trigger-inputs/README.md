# Solution: Trigger Inputs

This directory contains the solution for Exercise 3: Trigger Inputs.

## Files
- `hello-world.yml` - The GitHub Actions workflow file with input handling

## Key Features
- Manual trigger with custom inputs
- Required and optional input parameters
- Default values for optional inputs
- Personalized greeting using inputs
- Context information display

## Input Parameters
- `name` (required) - User's name for personalized greeting
- `greeting` (optional) - Custom greeting message, defaults to "Hello"

## Usage
1. Copy the workflow file to `.github/workflows/` in your repository
2. Commit and push the changes
3. Go to Actions tab and run the workflow
4. Fill in the input fields when prompted
5. Try different combinations of inputs

## What You'll Learn
- Workflow input definitions
- Required vs optional inputs
- Default values
- Accessing inputs via `github.event.inputs`
- Input types and validation
