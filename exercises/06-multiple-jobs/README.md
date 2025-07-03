# Exercise 6: Multiple Jobs

## Objective
Learn how to create workflows with multiple jobs, understand job dependencies, control parallel vs sequential execution, and use job-level conditions.

## Instructions

1. **Create a multi-job workflow**: Design a workflow that simulates a CI/CD pipeline with:
   - **Setup job**: Validates the environment and prepares for other jobs  
     This job should run on `ubuntu-latest` and do three things:
     - Print the Node.js and npm versions
     - Generate a `VERSION` output that is set to `1.0.<workflow run number>`
     - Generate a `deploy` output that is set to `true` if the current branch is `main`, otherwise `false`
   - **Test jobs**: Multiple jobs that can run in parallel (tests, linting)  
     - The test job should run on `ubuntu-latest` and simulate running tests (output some message and sleep for a few seconds).
     - The linting job should be a matrix job that runs on `ubuntu-latest` and `windows-latest`, simulating linting code (output some message and sleep for a few seconds).
   - **Build job**: Builds the application (depends on tests passing)  
     The build job should run on `ubuntu-latest` and create an artifact file (just use touch to create a file) and an output that contains the artifact name. It should then upload the artifact to GitHub Actions.
   - **Deploy job**: Deploys the application (depends on build completing)  
     The deploy job should run on `ubuntu-latest` and only run if the `deploy` output from the setup job is `true`. It should download the artifact, list the file, and simulate deployment by outputting a message and sleeping for a few seconds.
   - **Cleanup job**: Always runs at the end, regardless of previous job outcomes  
     The cleanup job should run on `ubuntu-latest` and output a message and the results of previous jobs.

2. **Configure job dependencies**: Set up proper job dependencies:
   - Test jobs should depend on setup job
   - Build job should depend on all test jobs
   - Deploy job should depend on build job
   - Add a cleanup job that always runs at the end

3. **Add parallel execution**: Configure jobs to run in parallel where appropriate:
   - Test jobs should run in parallel with each other
   - Show different operating systems for some jobs
   - Demonstrate job outputs and artifacts

4. **Handle job failures**: Configure the workflow to:
   - Continue with cleanup even if other jobs fail
   - Show conditional deployment based on test results
   - Use job outputs to pass data between jobs

## Key Concepts
- Multiple job definitions in a single workflow
- Job dependencies using `needs:`
- Parallel vs sequential job execution
- Job outputs using `outputs:`
- Job matrices for running on multiple OS/versions
- Conditional job execution
- `always()` job status function

## Expected Behavior
```
Setup Job (runs first)
      ↓
┌─- Tests ──┐
|           | (run in parallel)
└─ Linting -┘
      ↓
Build Job (waits for all tests)
      ↓
Deploy Job (waits for build)
      ↓
Cleanup Job (always runs)
```

## Advanced Features
- Job matrices to test multiple environments
- Uploading and downloading artifacts between jobs
- Setting job outputs and using them in dependent jobs

## Hints
- Use `needs: [ job1, job2 ]` for multiple dependencies
- Use `strategy.matrix` for running jobs with multiple configurations
- Job outputs: `outputs.key: ${{ steps.step-id.outputs.value }}`
- Access job outputs: `needs.job-name.outputs.output-name`
- Use `if: always()` for cleanup jobs
- Use different `runs-on` values to show OS diversity
- Use [`actions/upload-artifact@v4`](https://github.com/actions/upload-artifact/tree/v4) and [`actions/download-artifact@v4`](https://github.com/actions/download-artifact/tree/v4) for handling artifacts

## Running the Workflow
- Run the workflow on the `main` branch to see the deployment happen.
- Create a new branch and run the workflow for this branch to see the deployment skipped.
- Want to simulate a failure in one of the jobs? - Add inputs (`fail-setup`, `fail-build`, `fail-tests`, `fail-linting`, `fail-deploy`; type: `boolean`, default: `false`) to the workflow and use them to conditionally fail the jobs to see different behaviors.
  - What happens if you fail the linting process? - Ask your instructor to explain.

## Solution
If you get stuck, check the [solution](../../solutions/06-multiple-jobs/) directory for working examples.
