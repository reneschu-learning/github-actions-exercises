# Exercise 11: Simple Workflow with Azure Deployment (OIDC)
In this exercise, you will create a GitHub Actions workflow that deploys resources to Azure using OpenID Connect (OIDC) authentication. This approach eliminates the need to store long-lived secrets in your repository and provides enhanced security through federated identity credentials.

## Prerequisites
- **Completion of Exercise 10 (Service Principal authentication)**
- A GitHub account and a repository for this exercise
- An Azure subscription with permissions to create resources and manage federated credentials
- Azure CLI installed locally (for setup steps)

## Learning Objectives
By the end of this exercise, you will be able to:
- Understand the benefits of OIDC authentication over service principal secrets
- Configure federated identity credentials in Azure
- Set up OIDC authentication for GitHub Actions
- Deploy Azure resources using OIDC authentication
- Understand the security advantages of federated authentication

## Overview
This exercise will guide you through:
1. Understanding OIDC and federated identity
2. Creating an Azure AD application and configuring federated credentials
3. Setting up repository variables and secrets for OIDC
4. Creating a workflow that uses OIDC authentication
5. Comparing OIDC with service principal authentication

## What is OIDC Authentication?
OpenID Connect (OIDC) allows GitHub Actions to authenticate with Azure using short-lived tokens instead of long-lived secrets. This approach:

- **Eliminates secret storage:** No need to store service principal secrets in GitHub
- **Improves security:** Uses short-lived tokens that are automatically rotated
- **Reduces maintenance:** No need to manually rotate credentials
- **Provides better auditing:** More detailed authentication logs

## Step 1: Create Azure AD Application and Service Principal (if you haven't completed Exercise 10)

### 1.1 Login to Azure CLI
Open your terminal or command prompt and login to Azure:

```bash
az login
```

### 1.2 Set your subscription (if you have multiple)
```bash
az account set --subscription "Your Subscription Name or ID"
```

### 1.3 Create a service principal
Create a service principal with contributor access to your subscription:

```bash
az ad sp create-for-rbac --name "github-actions-sp" --role contributor --scopes /subscriptions/{subscription-id} --create-password false
```

**Note:** If multiple people are running this exercise in the same Entra ID tenant, you may want to use a unique name for your service principal to avoid conflicts. You can append your GitHub username or a random string to the name.

Replace `{subscription-id}` with your actual subscription ID. You can find your subscription ID by running:

```bash
az account show --query id --output tsv
```r \
  --scope /subscriptions/{subscription-id}
```

The output should look like this:
```json
{
  "appId": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",
  "displayName": "github-actions-sp",
  "password": null,
  "tenant": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
}
```

## Step 2: Configure Federated Identity Credentials
Federated identity credentials allow the Azure AD application to trust tokens from GitHub Actions. This trust relationship is tightly coupled with your GitHub repository and branch or other contexts, depending on whether your workflow simply runs for a branch, a tag, a pull request, a specific environment, or even executes a reusable workflow. If you want to learn about the different subject claims, you can refer to the [GitHub documentation on OIDC](https://docs.github.com/en/actions/concepts/security/about-security-hardening-with-openid-connect#example-subject-claims).

### Create federated credentials for main branch
For this exercise, we will just create a federated credential for the main branch. Run the following command:

```bash
az ad app federated-credential create \
  --id {appId} \
  --parameters '{
    "name": "github-actions-main",
    "issuer": "https://token.actions.githubusercontent.com",
    "subject": "repo:{github-username}/{repository-name}:ref:refs/heads/main",
    "description": "GitHub Actions OIDC for main branch",
    "audiences": ["api://AzureADTokenExchange"]
  }'
```

## Step 3: Configure Repository Variables
Remember that with OIDC, you don't need to store any secrets in your repository. Instead, you will use repository variables to store the necessary information for the workflow. Go to your repository → Settings → Secrets and variables → Actions → Variables tab:

1. **Name:** `AZURE_CLIENT_ID`
   **Value:** The `appId` from step 1.3

2. **Name:** `AZURE_TENANT_ID`
   **Value:** The `tenant` from step 1.3

3. **Name:** `AZURE_SUBSCRIPTION_ID`
   **Value:** Your Azure subscription ID


## Step 4: Updating the Workflow
Reuse the workflow you created in exercise 10 (or use the solution provided in the `solutions/10-azure-deployment-sp` directory) and modify it to use OIDC authentication instead of service principal authentication. To do so, simply change the inputs of the `azure/login` action from `creds` to `client-id`, `tenant-id`, and `subscription-id`. If you want to, you can also remove the `AZURE_CREDENTIALS` secret from your repository since it is no longer needed (note, this breaks the workflow from exercise 10, in case you make a copy for this exercise).

OIDC authentication requires additional permissions for the workflow, which are not included by default. Remember to add the `permissions` section to your workflow file and include `id-token: write` permission. This allows the workflow to request an OIDC token from GitHub.

## Step 5: Test the OIDC Workflow
Trigger the workflow and provide names for the resources (e.g., `rg-github-actions-workshop`, `sagithubactions`, `sampledata`).

Watch the workflow execution and verify that:
- The login step succeeds - watch for the message indicating that OIDC authentication is used
  - If the login failed, you likely forgot to add the `id-token: write` permission to your workflow (see above)
- The resource group is created
- The storage account is created
- The storage container is created
- All resources are listed at the end

## Step 6: Verify in Azure Portal

1. Go to the [Azure Portal](https://portal.azure.com)
2. Navigate to Resource Group
3. Find the resource group created by your workflow
4. Verify that the storage account and container were created successfully

## Step 7: Clean Up (Optional)
To avoid Azure charges, you can create a cleanup workflow or manually delete the resources:

### Manual cleanup:
```bash
az group delete --name {your-resource-group-name} --yes --no-wait
```

Replace `{your-resource-group-name}` with the name of the resource group you created.

### Automatic cleanup (optional)
If you have more time, add a cleanup job to your workflow that deletes the resources after the deployment is verified. Use an environment with an approval by yourself for this job to ensure that you have enough time to verify the resources before they are deleted.

## Additional Resources

- [GitHub OIDC documentation](https://docs.github.com/en/actions/deployment/security-hardening-your-deployments/about-security-hardening-with-openid-connect)
- [Azure federated identity credentials](https://docs.microsoft.com/en-us/azure/active-directory/develop/workload-identity-federation)
- [azure/login action OIDC documentation](https://github.com/Azure/login#login-with-openid-connect-oidc-recommended)
- [Azure Bicep documentation](https://docs.microsoft.com/en-us/azure/azure-resource-manager/bicep/)

## Key Takeaways
- OIDC provides enhanced security by eliminating long-lived secrets
- Federated identity credentials enable trust between GitHub and Azure
- Short-lived tokens reduce security risks and maintenance overhead
- OIDC requires more initial setup but provides better long-term security
- This approach is recommended for production deployments
