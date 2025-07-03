# Exercise 1: Hello World

## Objective
Create a simple GitHub Actions workflow that prints "Hello, World!" to the console when triggered manually.

## Instructions

1. **Create a workflow file**: In your repository, create a new file at `.github/workflows/hello-world.yml`

2. **Define the workflow**: Create a workflow with the following requirements:
   - Name: "Hello World"
   - Trigger: Manual trigger using `workflow_dispatch`
   - Job: A single job named "hello" that runs on `ubuntu-latest`
   - Step: A single step that prints "Hello, World!" to the console

3. **Test the workflow**: Commit and push your changes, then manually trigger the workflow from the GitHub Actions tab

## Key Concepts
- Basic GitHub Actions workflow structure
- Manual workflow triggers (`workflow_dispatch`)
- Jobs and steps
- Using `echo` command in workflow steps

## Expected Output
When you run the workflow, you should see "Hello, World!" printed in the workflow logs.

## Hints
- Use the `run` keyword to execute shell commands
- The basic structure of a workflow includes `name`, `on`, `jobs`, and within jobs: `runs-on` and `steps`
- Each step can have a `name` and either `run` or `uses`

## Solution
If you get stuck, check the [solution](../../solutions/01-hello-world/) directory for a working example.
