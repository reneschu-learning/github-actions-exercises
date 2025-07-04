# Exercise 10 Solution: Azure Deployment with Service Principal

This directory contains the solution for Exercise 10, which demonstrates how to deploy Azure resources using GitHub Actions with service principal authentication.

## Solution Overview

The solution includes:
- A GitHub Actions workflow that authenticates using a service principal
- Deployment of basic Azure resources (resource group, storage account, container)
- Proper secret management and security practices

## Workflows in this Solution
- `azure-deployment-sp.yml`  
  The main workflow file that demonstrates service principal authentication and resource deployment.
- `azure-deployment-sp-with-cleanup.yml`  
  An extended workflow that includes cleanup steps for resource deletion after deployment.

## Key Learning Points

### 1. Service Principal Authentication
- Uses `azure/login` action with stored credentials
- Requires the `AZURE_CREDENTIALS` secret with full JSON configuration
- Provides immediate access but requires secret management

### 2. Resource Deployment Pattern
- Creates resources using Azure CLI commands
- Implements proper tagging for resource management
- Includes verification steps

### 3. Security Considerations
- All sensitive information stored in GitHub secrets
- Service principal follows principle of least privilege
- No hardcoded credentials in workflow files

## Comparison with OIDC
| Feature | Service Principal | OIDC (Exercise 11) |
|---------|------------------|-------------------|
| Setup Complexity | Simple | Moderate |
| Secret Management | Required | Not Required |
| Security | Good | Excellent |
| Maintenance | Regular rotation | Minimal |
| Token Lifetime | Long-lived | Short-lived |

## Next Steps
After completing this exercise, proceed to Exercise 11 to learn about OIDC authentication, which provides enhanced security and eliminates the need for stored secrets.
