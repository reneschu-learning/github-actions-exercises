# Exercise 14: Accessing External Repositories

## Objective
In this exercise, you will learn how to access external repositories in your workflows using GitHub Apps. You will create a GitHub App, configure it with a private key, and use the `actions/create-github-app-token@v1` action to generate a token that allows your workflow to interact with issues in a different repository.

## Prerequisites
- Access to a GitHub organization or the ability to create one
- A second repository to interact with (you can create a test repository for this exercise)

## Learning Objectives
By the end of this exercise, you will understand:
- How to create and configure a GitHub App
- How to generate and store private keys securely
- How to use the `actions/create-github-app-token@v1` action
- How to authenticate and interact with external repositories using GitHub Apps
- Security best practices when working with GitHub Apps

## Background
Sometimes you need your workflows to interact with repositories other than the one where the workflow is running. For example, you might want to:
- Create issues in a documentation repository when a bug is found
- Update a status repository with deployment information
- Trigger workflows in other repositories
- Access code or data from private repositories

While you could use a personal access token (PAT) for this purpose, GitHub Apps provide a more secure and scalable approach:
- **Granular permissions**: You can limit what the app can access
- **Installation-based**: The app is installed only where needed
- **Organization-level management**: Organization owners can manage app installations
- **Audit trail**: All actions are clearly attributed to the app
- **Token expiration**: Tokens are short-lived and automatically refreshed

## Step 1: Create a Target Repository
First, create a test repository that your workflow will interact with:

1. Create a new repository in your organization (or personal account) named `external-repo-test`
2. You can make it public, private, or internal (for enterprise accounts)
3. Note the repository's full name (e.g., `your-org/external-repo-test`)

## Step 2: Create a GitHub App
1. **Navigate to GitHub App Settings**:
   - Go to your organization settings (or personal account settings)
   - Click on "Developer settings" in the left sidebar
   - Click on "GitHub Apps"
   - Click "New GitHub App"

2. **Configure the GitHub App**:
   - **GitHub App name**: `External Repo Access App` (or any **globally** unique name)
   - **Description**: `App for accessing external repositories in workflows`
   - **Homepage URL**: `https://localhost`  
     This must be a valid URL, but since we don't deploy an actual application represented by this app, you can use a placeholder like `https://localhost`.
   - **Webhook**: Uncheck "Active" (we don't need webhooks for this exercise)

3. **Set Permissions**:
   Under "Repository permissions":
   - **Issues**: `Write` (to create issues)
   - **Metadata**: `Read` (basic repository access)
   - **Contents**: `Read` (to read repository contents)

4. **Choose Installation Options**:
   - Select "Only on this account" for simplicity

5. **Create the App**:
   - Click "Create GitHub App"
   - Note down the **App ID** from the app's settings page

## Step 3: Generate and Download Private Key
1. **Generate Private Key**:
   - On your GitHub App's settings page, scroll down to "Private keys"
   - Click "Generate a private key"
   - A `.pem` file will be downloaded to your computer

2. **Prepare the Private Key**:
   - Open the downloaded `.pem` file in a text editor
   - Copy the entire contents (including the `-----BEGIN RSA PRIVATE KEY-----` and `-----END RSA PRIVATE KEY-----` lines)

## Step 4: Install the GitHub App
1. **Install the App**:
   - Go to your GitHub App's settings page
   - Click "Install App" in the left sidebar
   - Click "Install" next to your organization/account
   - Choose "Selected repositories" and select the target repository you created in Step 1
   - Click "Install"

## Step 5: Configure Repository Secrets
In your workflow repository (where you'll create the workflow):

1. **Add Repository Secrets**:
   - Go to Settings → Secrets and variables → Actions
   - Click "New repository secret"
   - Create the following secrets:
     - **Name**: `APP_ID`
     - **Value**: The App ID from Step 2
   - Create another secret:
     - **Name**: `APP_PRIVATE_KEY`
     - **Value**: The entire private key content from Step 3

## Step 6: Create the Workflow
Create a workflow file `.github/workflows/external-repo-access.yml` with the following requirements:

1. **Trigger**: Manual trigger (`workflow_dispatch`) with inputs:
   - `target_repo`: The repository to create an issue in (default: the test repo you created)
   - `issue_title`: Title for the issue to create
   - `issue_body`: Body content for the issue

2. **Jobs**:
   - A single job that uses the GitHub App to create an issue in the target repository

3. **Steps**:
   - Generate a token using the GitHub App
   - Create an issue in the target repository using GitHub CLI
   - Output the URL of the created issue

## Step 7: Test the Workflow
1. **Trigger the Workflow**:
   - Go to Actions → External Repo Access → Run workflow
   - Provide inputs:
     - Target repo: `your-org/external-repo-test`
     - Issue title: `Test issue from workflow`
     - Issue body: `This issue was created by a GitHub Actions workflow using a GitHub App token.`

2. **Verify Results**:
   - Check that the workflow runs successfully
   - Verify that an issue was created in the target repository
   - Confirm that the issue is attributed to your GitHub App

## Key Points and Best Practices

### Security Considerations
- **Private Key Protection**: Never expose private keys in logs or code
- **Minimal Permissions**: Only grant the permissions your app actually needs
- **Token Lifecycle**: GitHub App tokens are short-lived (1 hour) and automatically expire
- **Installation Scope**: Install the app only on repositories that need it

### GitHub App vs. Personal Access Token
- **GitHub Apps** are preferred for organization use because:
  - They don't depend on individual user accounts
  - They provide better audit trails
  - They have more granular permissions
  - They can be managed at the organization level

## Troubleshooting
### Common Issues
1. **"App not installed" errors**: Ensure the app is installed on the target repository
2. **Permission denied**: Check that the app has the necessary permissions
3. **Invalid private key**: Ensure the entire key (including headers) is copied correctly
4. **Repository not found**: Verify the repository name format (`owner/repo`)

## Expected Outcome
After completing this exercise, you should have:
- A working GitHub App with proper permissions
- A workflow that can authenticate using the app
- Successfully created an issue in an external repository
- Understanding of GitHub App security and best practices
