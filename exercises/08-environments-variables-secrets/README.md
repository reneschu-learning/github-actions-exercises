# Exercise 8: Environments, Variables, and Secrets

## Learning Objectives
In this exercise, you will learn how to:
- Create and use environments to control access to jobs
- Use repository variables and environment variables
- Use *local* environment variables to store reusable values within the workflow (or to mitigate script injection)
- Store and use secrets securely in workflows
- Understand the precedence of variables and secrets
- Configure environment protection rules

## Background
Environments, variables, and secrets are essential components for managing configuration and sensitive data in GitHub Actions workflows. They allow you to:
- Separate configuration between different deployment stages (dev, staging, production)
- Store sensitive information like API keys, passwords, and tokens securely
- Control access to specific environments with protection rules
- Maintain different configurations for different branches or deployment targets

## Instructions

### Part 1: Create Repository Variables
1. In your repository, go to **Settings > Secrets and variables > Actions**
2. Click on the **Variables** tab
3. Create the following repository variables:
   - `APP_NAME`: Set to `my-awesome-app`
   - `DEFAULT_REGION`: Set to `us-east-1`

### Part 2: Create Environments and Environment Variables
1. In your repository, go to **Settings > Environments**
2. Create two environments:
   - `development`
   - `production`
3. For the `development` environment:
   - Add environment variable `ENVIRONMENT_NAME`: `dev`
   - Add environment variable `API_URL`: `https://dev-api.example.com`
4. For the `production` environment:
   - Add environment variable `ENVIRONMENT_NAME`: `prod`
   - Add environment variable `API_URL`: `https://api.example.com`
   - Configure protection rules:
     - Required reviewers: Add yourself
     - Wait timer: 1 minute

### Part 3: Create Secrets
1. Go back to **Settings > Secrets and variables > Actions**
2. Click on the **Secrets** tab
3. Create a repository secret:
   - `API_KEY`: Set to `super-secret-api-key-12345`
4. For each environment (`development` and `production`):
   - Add environment secret `DATABASE_PASSWORD`:
     - Development: `dev-password-123`
     - Production: `prod-password-xyz`

### Part 4: Create the Workflow
Create a workflow file `.github/workflows/environments-variables-secrets.yml` with the following requirements:

1. **Trigger**: Manual trigger with inputs:
   - `environment`: Choice input with options `development` and `production`
   - `deploy_version`: String input for version number

2. **Local Variables**:
   - Use `env` to define local variables within the workflow
   - Example: `actor: ${{ github.actor }}`

3. **Jobs**:
   - `deploy`: 
     - Uses the environment specified in the input
     - Displays all variables and secrets
     - Shows the precedence of variables (repository vs environment)

### Part 5: Test the Workflow
1. Run the workflow manually and select the `development` environment
2. Observe how variables and secrets are accessed
3. Run the workflow again with the `production` environment
4. Notice the protection rules in action for the production environment

## Expected Outcome
After completing this exercise, you should have:
- A workflow that demonstrates the use of environments, variables, and secrets
- Understanding of how environment protection rules work
- Knowledge of variable and secret precedence
- Experience with different types of variables and secrets

## Key Concepts
- **Repository Variables**: Available to all environments and workflows
- **Environment Variables**: Specific to an environment, override repository variables
- **Repository Secrets**: Available to all environments and workflows
- **Environment Secrets**: Specific to an environment, override repository secrets
- **Environment Protection Rules**: Control access to environments
- **Variable Precedence**: Environment > Repository
- **Secret Precedence**: Environment > Repository

## Tips
- Always use secrets for sensitive information, never variables
- Environment variables and secrets override repository-level ones
- Environment protection rules are crucial for production deployments
- Use meaningful names for your variables and secrets
- Test with both environments to see the differences

## Next Steps
In the next exercise, you'll build a complete CI/CD pipeline that incorporates these concepts along with building, testing, and deploying applications.
