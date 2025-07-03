# Solution: Multiple Jobs

This directory contains the solution for Exercise 6: Multiple Jobs.

## Files
- `multi-job-pipeline.yml` - Sample multi-job CI/CD pipeline workflow
- `multi-job-pipeline-with-failures.yml` - Sample multi-job CI/CD pipeline workflow and error simulation

## Key Features
- Six-job CI/CD pipeline simulation
- Job dependencies and sequencing
- Parallel test execution
- Job outputs and inter-job communication
- Conditional deployment
- Matrix strategy for multi-OS testing
- Always-running cleanup job

## Job Flow
```
Setup → Tests (parallel) → Build → Deploy → Cleanup
        ├─ Unit Tests
        └─ Linting (multi-OS)
```

## Job Dependencies
- Tests depend on Setup
- Build depends on all Tests
- Deploy depends on Setup + Build
- Cleanup always runs (depends on all)

## Advanced Features
- Job outputs (`VERSION`, `deploy`)
- Matrix strategy for OS testing
- Conditional deployment based on branch
- Comprehensive status reporting

## Usage
1. Copy the workflow file to `.github/workflows/` in your repository
2. Commit and push the changes
3. Trigger workflow
4. Observe job execution order and parallel processing

## What You'll Learn
- Multi-job workflow design
- Job dependencies with `needs:`
- Parallel vs sequential execution
- Job outputs and communication
- Matrix strategies
- Conditional job execution
- Production deployment patterns
