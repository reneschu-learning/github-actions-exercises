# Solution: Exercise 8 - Environments, Variables, and Secrets

This solution demonstrates how to use environments, variables, and secrets in GitHub Actions workflows.

## Files
- `environments-variables-secrets.yml`: The main workflow file

## Key Features

### 1. Workflow Inputs
- Uses `workflow_dispatch` trigger with two inputs
- `environment`: Choice input for selecting target environment
- `deploy_version`: String input for specifying deployment version

### 2. Environment Usage
- The job uses the environment specified in the input: `environment: ${{ inputs.environment }}`
- This allows the workflow to access environment-specific variables and secrets

### 3. Variables Demonstration
- Shows how to access repository variables: `${{ vars.VARIABLE_NAME }}`
- Shows how to access environment variables (same syntax, but environment takes precedence)
- Demonstrates variable precedence (environment overrides repository)
- Shows how to define local variables within the workflow using `env` and access them with `${{ env.VARIABLE_NAME }}`
  - **Note:** Local variables are not exposed to the job environment, but can be used within the workflow steps. Thus, you cannot use local variables to set inputs of reusable workflows.  

### 4. Secrets Usage
- Safely demonstrates secret usage without exposing values
- Shows that secret values are automatically masked in logs
- Uses conditional checking to verify secrets exist: `${{ secrets.SECRET_NAME != '' }}`

## Setup Instructions

### Repository Variables
Create these in **Settings > Secrets and variables > Actions > Variables**:
- `APP_NAME`: `my-awesome-app`
- `DEFAULT_REGION`: `us-east-1`

### Environments
Create these in **Settings > Environments**:

#### Development Environment
- Environment variables:
  - `ENVIRONMENT_NAME`: `dev`
  - `API_URL`: `https://dev-api.example.com`
- Environment secrets:
  - `DATABASE_PASSWORD`: `dev-password-123`

#### Production Environment
- Environment variables:
  - `ENVIRONMENT_NAME`: `prod`
  - `API_URL`: `https://api.example.com`
- Environment secrets:
  - `DATABASE_PASSWORD`: `prod-password-xyz`
- Protection rules:
  - Required reviewers
  - Wait timer: 5 minutes

### Repository Secrets
Create these in **Settings > Secrets and variables > Actions > Secrets**:
- `API_KEY`: `super-secret-api-key-12345`

## Testing
1. Run the workflow with the `development` environment - should execute immediately
2. Run the workflow with the `production` environment - should require approval and wait timer
3. Compare the output to see how environment variables override repository variables

## Security Best Practices Demonstrated
- Secrets are automatically masked in logs
  - **Note:** Keep in mind that masking secrets just provides best-effort protection. Secrets can still be exposed through artifacts, as transformed values in logs, or through other means. If possible, avoid using secrets in your workflows. E.g., [exercise 11](./exercises/11-full-ci-cd-pipeline-azure-deployment-oidc/README.md) demonstrates how to use OIDC authentication to avoid using secrets when connecting to Azure.
- Environment protection rules prevent unauthorized production deployments
- Separation of configuration between environments
- Safe handling of sensitive information
