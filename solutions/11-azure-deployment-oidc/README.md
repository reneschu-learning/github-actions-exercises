# Exercise 11 Solution: Azure Deployment with OIDC
This directory contains the solution for Exercise 11, which demonstrates how to deploy Azure resources using GitHub Actions with OpenID Connect (OIDC) authentication.

## Solution Overview
The solution includes:
- A GitHub Actions workflow that authenticates using OIDC
- Deployment of basic Azure resources (resource group, storage account, container)
- Proper secret management and security practices
- Error handling and cleanup procedures

## Workflows in this Solution
- `azure-deployment-oidc.yml`  
  The main workflow file that demonstrates OIDC authentication and resource deployment.
- `azure-deployment-oidc-with-cleanup.yml`  
  An extended workflow that includes cleanup steps for resource deletion after deployment.

## Key Learning Points

### 1. OIDC Authentication
- Uses `azure/login` action with OIDC
- Eliminates the need for long-lived secrets
- Provides immediate access with short-lived tokens

### 2. Resource Deployment Pattern
- Creates resources using Azure CLI commands
- Implements proper tagging for resource management
- Includes verification steps

### 3. Security Considerations
- No sensitive information stored
- Service principal follows principle of least privilege
- No hardcoded credentials in workflow files

## Comparison with Service Principal ID/Secret
| Feature | Service Principal (Exercise 10) | OIDC |
|---------|------------------|-------------------|
| Setup Complexity | Simple | Moderate |
| Secret Management | Required | Not Required |
| Security | Good | Excellent |
| Maintenance | Regular rotation | Minimal |
| Token Lifetime | Long-lived | Short-lived |
