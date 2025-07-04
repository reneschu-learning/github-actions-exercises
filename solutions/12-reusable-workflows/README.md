# Solution: Exercise 12 - Reusable Workflows
This solution demonstrates how to refactor a CI/CD pipeline using reusable workflows to eliminate duplication and improve maintainability.

## Files
- `ci-cd-pipeline.yml`: Main workflow that calls reusable workflows
- `reusable-deploy.yml`: Reusable deployment workflow

## Solution Overview

### 🔄 Reusable Deployment Workflow (`reusable-deploy.yml`)
**Purpose**: Handles deployment to any environment with configurable parameters.

**Inputs**:
- `environment` (required): Target environment name (development/production)
- `package-name` (required): Name of the artifact to deploy
- `app-url` (required): URL where the application will be deployed
- `is-production` (optional): Boolean flag for production-specific steps

**Outputs**:
- `deployment-status`: Success or failure status

**Features**:
- Environment-specific deployments
- Conditional production steps (running application, creating release tags)
- Deployment summaries with metadata
- Artifact downloading and verification

### 🔗 Main Workflow (`ci-cd-pipeline.yml`)

**Changes from Exercise 9**:
- `build` and `package` jobs remain unchanged
- `deploy-dev` now calls `reusable-deploy.yml` with development parameters
- `deploy-prod` now calls `reusable-deploy.yml` with production parameters
- `notify` job has been updated to use outputs from the reusable deployment workflows

## Key Features Demonstrated

### 1. Workflow Calls
```yaml
deploy-dev:
  uses: ./.github/workflows/reusable-deploy.yml
  with:
    environment: 'development'
    package-name: 'deployment-package'
    app-url: 'https://dev-sampleapp.example.com'
  secrets: inherit
```

### 2. Input/Output Management
**Inputs** allow parameterization:
```yaml
on:
  workflow_call:
    inputs:
      environment:
        required: true
        type: string
        description: 'Target environment'
```

**Outputs** enable data sharing:
```yaml
outputs:
  deployment-status:
    description: 'Status of the deployment'
    value: ${{ jobs.deploy.outputs.status }}
```

### 3. Conditional Logic
Production-specific steps using input flags:
```yaml
- name: 🔧 Setup .NET (Production only)
  if: inputs.is-production
  uses: actions/setup-dotnet@v4
```

### 4. Status Propagation
Using job outputs in the notification job:
```yaml
with:
  dev-status: ${{ needs.deploy-dev.outputs.deployment-status }}
  prod-status: ${{ needs.deploy-prod.outputs.deployment-status }}
```

### 5. Permission Inheritance
```yaml
permissions:
  contents: write
secrets: inherit
```

## Benefits Achieved

### ✅ Reduced Duplication
- Deployment logic written once, used twice
- Notification logic centralized
- Consistent behavior across environments

### ✅ Improved Maintainability  
- Changes to deployment process only need to be made in one place
- Clear separation of concerns
- Easier to test individual components

### ✅ Better Organization
- Focused workflows with single responsibilities
- Clear input/output contracts
- Reusable across multiple projects

### ✅ Enhanced Flexibility
- Parameterized deployments
- Environment-specific configurations
- Easy to add new environments
