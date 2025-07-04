# Exercise 14 Solution: Accessing External Repositories
This directory contains the solution for Exercise 14, demonstrating how to use GitHub Apps to access external repositories in workflows.

## Solution Overview
The solution demonstrates:
- Creating and configuring a GitHub App with appropriate permissions
- Using the `actions/create-github-app-token@v1` action to generate authentication tokens
- Creating issues in external repositories using GitHub CLI
- Proper error handling and security practices

## Files Included
- `external-repo-access.yml`: Complete workflow that creates issues in external repositories using GitHub App authentication

## Key Implementation Details
### GitHub App Configuration
The solution assumes a GitHub App configured with:
- **Repository permissions**:
  - Issues: Write
  - Metadata: Read
  - Contents: Read
- **Installation**: Installed on target repositories

### Required Secrets
The workflow requires two repository secrets:
- `APP_ID`: The GitHub App ID (numeric)
- `APP_PRIVATE_KEY`: The complete private key content (including BEGIN/END headers)

### Security Features
- Private key is never exposed in logs
- Token is generated fresh for each run
- Error handling prevents sensitive data leakage
- Proper validation of inputs and outputs

## How to Use This Solution
1. **Set up GitHub App**: Follow the exercise instructions to create and configure your GitHub App
2. **Configure Secrets**: Add `APP_ID` and `APP_PRIVATE_KEY` to your repository secrets
3. **Deploy Workflow**: Copy the workflow file to `.github/workflows/` in your repository
4. **Test**: Run the workflow manually with appropriate inputs

## Testing the Solution
1. **Manual Trigger**:
   ```
   Repository: your-org/target-repo
   Issue Title: Test Issue from GitHub App
   Issue Body: This demonstrates external repository access
   ```

2. **Expected Results**:
   - Workflow completes successfully
   - New issue appears in target repository
   - Issue is attributed to your GitHub App
   - Workflow output shows the issue URL

## Advanced Usage
Using the `actions/create-github-app-token@v1` action to get an app token allows you to perform many actions on other repositories like cloning them to use private custom actions that GitHub Actions does not have direct access to. Assume you have put a custom action a private repository `private-action-repo`and you want to use it in your workflow. You can use the GitHub App token to clone the repository and use the action in your workflow like this:

```yaml
steps:
  - name: Generate GitHub App Token
    id: generate-token
    uses: actions/create-github-app-token@v1
    with:
      app-id: ${{ secrets.APP_ID }}
      private-key: ${{ secrets.APP_PRIVATE_KEY }}
      repositories: your-org/private-action-repo

  - name: Checkout Action Repository
    uses: actions/checkout@v4
    with:
      repository: your-org/private-action-repo
      token: ${{ steps.generate-token.outputs.token }}
      path: private-action-repo

  - name: Run Private Action Locally
    uses: ./private-action-repo/
    with:
      some-input: 'value'
```
