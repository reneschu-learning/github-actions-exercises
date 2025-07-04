# Exercise 9: Full CI/CD Pipeline

## Learning Objectives
In this exercise, you will learn how to:
- Create a complete CI/CD pipeline with multiple jobs to build, test, and deploy a .NET application
- Use popular GitHub Actions like `actions/checkout` and `actions/setup-dotnet`
- Build, test, and package a .NET application
- Use artifacts to pass build outputs between jobs
- Implement proper job dependencies and workflow structure
- Use matrix strategies for testing across multiple versions

## Background
A CI/CD (Continuous Integration/Continuous Deployment) pipeline is essential for modern software development. It automates the process of building, testing, and deploying applications, ensuring code quality and enabling rapid, reliable releases.

This exercise brings together everything you've learned so far to create a realistic CI/CD pipeline for a .NET console application.

## Instructions

### Part 1: Examine the Sample Application
1. Look at the sample .NET console application provided in the `sample-app` directory
2. Understand the project structure and dependencies
3. Note the test project and how it's structured

### Part 2: Create the CI/CD Pipeline
Create a workflow file `.github/workflows/ci-cd-pipeline.yml` with the following jobs:

#### Build and Test Job
- Checkout the code using [actions/checkout@v4](https://github.com/actions/checkout/tree/v4)
- Set up .NET using [actions/setup-dotnet@v4](https://github.com/actions/setup-dotnet/tree/v4)
- Restore dependencies
- Build the application
- Run unit tests
- Generate test reports
- Upload test results
- Upload build artifacts

#### Package Stage (depends on Build and Test)
- Download build artifacts
- Package the application
- Upload packaged artifacts

#### Deploy Stage (depends on Package)
- Download packaged artifacts
- Simulate deployment to different environments
- Use environments from the previous exercise

### Part 3: Enhanced Features
Add these advanced features to your pipeline:

1. **Matrix Strategy**: Test against multiple .NET versions (6.0, 8.0)
2. **Conditional Deployment**: Only deploy on main branch
3. **Version Tagging**: Automatically tag successful deployments
4. **Notifications**: Add job status notifications

### Part 4: Triggers
Configure the workflow to trigger on:
- Push to main branch
- Pull requests to main branch
- Manual trigger with environment selection

## Sample Application Structure
The sample application includes:
- A simple .NET console application
- Unit tests using xUnit
- Proper project file configuration
- A solution file to tie everything together

## Expected Outcome
After completing this exercise, you should have:
- A complete CI/CD pipeline that builds, tests, and deploys a .NET application
- Understanding of job dependencies and artifact management
- Experience with matrix strategies and conditional logic
- A working example of environment-based deployments

## Key Concepts
- **Continuous Integration**: Automatically building and testing code changes
- **Continuous Deployment**: Automatically deploying tested code to environments
- **Artifacts**: Files produced by jobs that can be shared between jobs
- **Job Dependencies**: Using `needs` to control job execution order
- **Matrix Strategy**: Running jobs with different configurations
- **Environment Promotion**: Deploying through different environments (dev → staging → prod)

## Tips
- Use meaningful job and step names
- Keep build artifacts small by only including necessary files
- Use appropriate timeouts for different stages
- Consider using caching for dependencies to speed up builds
- Make sure to handle both success and failure scenarios

## Next Steps
In the next exercise, you'll extend this pipeline to deploy to Azure using service principal authentication.
