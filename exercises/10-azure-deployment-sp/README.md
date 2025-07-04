# Exercise 10: Simple Workflow with Azure Deployment (Service Principal)
In this exercise, you will create a GitHub Actions workflow that deploys resources to Azure using a service principal for authentication. You'll learn how to create and configure a service principal, set up repository secrets, and deploy Azure resources using GitHub Actions.

## Prerequisites
- An Azure subscription with permissions to create resources and service principals
- Azure CLI installed locally (for setup steps)

## Learning Objectives
By the end of this exercise, you will be able to:
- Create and configure an Azure service principal for GitHub Actions
- Set up repository secrets for secure authentication
- Use the `azure/login` action to authenticate with Azure
- Deploy Azure resources using GitHub Actions
- Understand the security considerations of service principal authentication

## Overview
This exercise will guide you through:
1. Creating a service principal in Azure
2. Configuring repository secrets in GitHub
3. Creating a workflow that deploys basic Azure resources
4. Understanding service principal permissions and security

## Step 1: Create an Azure Service Principal
First, you need to create a service principal that GitHub Actions can use to authenticate with Azure.

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
az ad sp create-for-rbac --name "github-actions-sp" --role contributor --scopes /subscriptions/{subscription-id} --json-auth
```

**Note:** If multiple people are running this exercise in the same Entra ID tenant, you may want to use a unique name for your service principal to avoid conflicts. You can append your GitHub username or a random string to the name.

Replace `{subscription-id}` with your actual subscription ID. You can find your subscription ID by running:

```bash
az account show --query id --output tsv
```

**Important:** Save the JSON output from the service principal creation command. You'll need it in the next step.

The output should look like this:
```json
{
  "clientId": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",
  "clientSecret": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",
  "subscriptionId": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",
  "tenantId": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",
  "activeDirectoryEndpointUrl": "https://login.microsoftonline.com",
  "resourceManagerEndpointUrl": "https://management.azure.com/",
  "activeDirectoryGraphResourceId": "https://graph.windows.net/",
  "sqlManagementEndpointUrl": "https://management.core.windows.net:8443/",
  "galleryEndpointUrl": "https://gallery.azure.com/",
  "managementEndpointUrl": "https://management.core.windows.net/"
}
```

## Step 2: Configure Repository Secrets
Now you need to add the service principal credentials to your GitHub repository as secrets.

### 2.1 Navigate to your repository settings
1. Go to your GitHub repository
2. Click on **Settings** tab
3. In the left sidebar, click on **Secrets and variables** → **Actions**

### 2.2 Add repository secrets
Click **New repository secret** and add the following secrets:

1. **Name:** `AZURE_CREDENTIALS`
   **Value:** The entire JSON output from the service principal creation command

   **Note:** The `azure/login` action just needs the `clientId`, `clientSecret`, `tenantId`, and `subscriptionId` fields from the JSON. The rest of the JSON structure will be ignored. If you want to, you can remove the unnecessary fields to keep it clean.

2. **Name:** `AZURE_SUBSCRIPTION_ID` (optional - not needed for the exercise)
   **Value:** Your Azure subscription ID

   **Note:** You don't need to create your subscription ID as a secret since it is not sensitive information. If you want to, you can create a repository variable instead or extract it from the `AZURE_CREDENTIALS` secret in your workflow using the `fromJson` function.

**Note:** In most real-world scenarios, you would usually put these secrets in an environment to ensure that different identities are used based on the target environment (e.g., dev, staging, prod).

## Step 3: Create the Workflow
Create a workflow file `.github/workflows/azure-deployment-sp.yml` with the following content:

### 3.1 Triggers
Configure the workflow to be triggered manually with inputs for resource group name, storage account name, and storage container name.

### 3.2 Workflow Content
1. Authenticate with Azure using the [azure/login@v2](https://github.com/Azure/login/tree/v2?tab=readme-ov-file#login-with-a-service-principal-secret) action
2. Create a resource group using the Azure CLI
3. Create a storage account within the resource group and a container within that account
4. List the resources created for verification

## Step 4: Test the Workflow
Trigger the workflow and provide names for the resources (e.g., `rg-github-actions-workshop`, `sagithubactions`, `sampledata`).

Watch the workflow execution and verify that:
- The login step succeeds
- The resource group is created
- The storage account is created
- The storage container is created
- All resources are listed at the end

## Step 5: Verify in Azure Portal

1. Go to the [Azure Portal](https://portal.azure.com)
2. Navigate to Resource Group
3. Find the resource group created by your workflow
4. Verify that the storage account and container were created successfully

## Step 6: Clean Up (Optional)
To avoid Azure charges, you can create a cleanup workflow or manually delete the resources:

### Manual cleanup:
```bash
az group delete --name {your-resource-group-name} --yes --no-wait
```

Replace `{your-resource-group-name}` with the name of the resource group you created.

### Automatic cleanup (optional)
If you have more time, add a cleanup job to your workflow that deletes the resources after the deployment is verified. Use an environment with an approval by yourself for this job to ensure that you have enough time to verify the resources before they are deleted.

## Security Considerations
When using service principals for authentication:

1. **Principle of Least Privilege:** Only grant the minimum permissions necessary
2. **Credential Rotation:** Regularly rotate service principal secrets
3. **Secret Management:** Never commit secrets to your repository
4. **Monitoring:** Monitor service principal usage and access patterns
5. **Scope Limitation:** Limit service principal scope to specific resource groups when possible

However, even with these considerations, workflows that use service principals with client ID and secret are still vulnerable to credential theft/leakage. Thus, try to avoid using secrets for your deployments and move to flows like OpenID Connect (OIDC) authentication. 

## Next Steps
In the next exercise (Exercise 11), you'll learn how to use OpenID Connect (OIDC) authentication, which eliminates the need to store secrets and provides better security.

## Troubleshooting
### Common Issues:
1. **Authentication failures:** Verify that your `AZURE_CREDENTIALS` secret contains the complete JSON output
2. **Permission errors:** Ensure the service principal has the necessary permissions
3. **Resource naming conflicts:** Storage account names must be globally unique
4. **Subscription access:** Verify that the service principal has access to the correct subscription

### Useful commands for debugging:

```bash
# Check current Azure context
az account show

# List service principals
az ad sp list --display-name "github-actions-sp"

# Check service principal permissions
az role assignment list --assignee {service-principal-id}
```

## Additional Resources

- [Azure Service Principal documentation](https://docs.microsoft.com/en-us/azure/active-directory/develop/app-objects-and-service-principals)
- [azure/login action documentation](https://github.com/Azure/login)
- [GitHub Actions secrets documentation](https://docs.github.com/en/actions/security-guides/encrypted-secrets)
- [Azure CLI reference](https://docs.microsoft.com/en-us/cli/azure/)
