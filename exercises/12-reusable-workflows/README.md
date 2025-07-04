# Exercise 12: Reusable Workflows

## Objective
In this exercise, you will learn how to create reusable workflows that can be called from other workflows. You will refactor the CI/CD pipeline from Exercise 9 to reduce duplication by extracting the deployment jobs into separate reusable workflows.

## Background
Reusable workflows allow you to eliminate duplication and make your workflows more maintainable. Instead of copying and pasting similar job definitions across multiple workflows, you can define a workflow once and call it from multiple places with different inputs.

Key benefits of reusable workflows:
- **Reduced duplication**: Write once, use many times
- **Easier maintenance**: Update logic in one place
- **Consistency**: Ensure all workflows use the same deployment process
- **Better organization**: Separate concerns into focused workflows

## What You'll Learn
- How to create reusable workflows with inputs and outputs
- How to call reusable workflows from other workflows
- How to pass data between the caller and reusable workflows
- Best practices for organizing reusable workflows

## Instructions

### Step 1: Create Reusable Deployment Workflow
Create a new workflow file at `.github/workflows/reusable-deploy.yml` that contains a reusable workflow for deployments. This workflow should:

1. Accept the following inputs:
   - `environment`: The target environment (development/production)
   - `package-name`: The name of the artifact package to deploy
   - `app-url`: The URL where the application will be deployed

2. Include the following outputs:
   - `deployment-status`: Whether the deployment was successful

3. Extract the deployment logic from the original workflow (download package, deploy, create summary). Ensure that you properly handle the special cases for production deployments, such as running the application and creating release tags.

### Step 2: Update Main Workflow
Modify your main CI/CD workflow to:

1. Keep the `build` and `package` jobs as they are
2. Replace the `deploy-dev` job with a call to the reusable deployment workflow
3. Replace the `deploy-prod` job with a call to the reusable deployment workflow
4. Update the `notify` job to use the outputs from the reusable deployment workflows
5. Ensure proper job dependencies are maintained

### Step 3: Test the Workflow
1. Commit and push your changes to trigger the workflow
2. Test manual dispatch with different environment selections
3. Verify that the reusable workflows are called correctly
4. Check that artifacts are properly passed between workflows

## Key Concepts

### Reusable Workflow Definition
```yaml
name: Reusable Deployment

on:
  workflow_call:
    inputs:
      environment:
        required: true
        type: string
        description: 'Target environment'
    outputs:
      deployment-status:
        description: 'Deployment status'
        value: ${{ jobs.deploy.outputs.status }}
```

### Calling a Reusable Workflow
```yaml
jobs:
  deploy:
    uses: ./.github/workflows/reusable-deploy.yml
    with:
      environment: 'development'
      package-name: 'deployment-package'
    secrets: inherit
```

### Input Types
Reusable workflows support various input types:
- `string`: Text values
- `number`: Numeric values  
- `boolean`: True/false values
- `choice`: Predefined options

### Secrets and Permissions
- Use `secrets: inherit` to pass all secrets to the reusable workflow
- Or explicitly pass specific secrets with the `secrets` key
- Permissions are inherited by default but can be overridden

**Note:** Secrets are not really needed for this exercise. We simply use them to demonstrate how to pass secrets to reusable workflows.

## Expected Files
After completing this exercise, you should have:
- `.github/workflows/reusable-deploy.yml` - Reusable deployment workflow
- `.github/workflows/ci-cd-pipeline.yml` - Updated main workflow that calls the reusable workflows

## Tips
- Reusable workflows must be in the `.github/workflows` directory
- Use descriptive names for inputs and outputs
- Add good descriptions to help other developers understand the purpose
- Test with different input combinations to ensure robustness
- Consider adding input validation where appropriate

## Verification
To verify your solution works:
1. Trigger the workflow manually and select development environment
2. Check that the reusable workflows are called in the GitHub Actions UI
3. Verify that deployment summaries are created correctly
4. Test production deployment
5. Confirm that notifications work as expected

## Next Steps
After completing this exercise, you'll have experience with reusable workflows. In the next exercise, you'll learn about custom composite actions, which provide another way to make your workflows more reusable and maintainable.
