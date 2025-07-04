# Exercise 13: Custom Composite Actions

## Objective
In this exercise, you will learn how to create custom composite actions that encapsulate multiple steps into a single reusable unit. You will extract the tagging functionality from the reusable workflow created in Exercise 12 and convert it into a composite action that can be reused across multiple workflows.

## Background
Composite actions are a way to group multiple workflow steps into a single reusable action. Unlike reusable workflows that create separate jobs, composite actions run as part of the existing job, making them ideal for:

- Encapsulating common sequences of steps
- Reducing duplication within jobs
- Creating reusable building blocks for workflows
- Sharing logic without introducing job overhead

Key benefits of composite actions:
- **No job boundaries**: Steps run in the same job context
- **Faster execution**: No job setup/teardown overhead
- **Shared context**: Access to the same environment variables and filesystem
- **Easier debugging**: All steps appear in the same job log
- **Input/Output support**: Pass data in and out of the action

## What You'll Learn
- How to create composite actions with `action.yml`
- How to define inputs and outputs for composite actions
- How to use composite actions in workflows
- How to make actions available across repositories
- Best practices for composite action design

## Instructions

### Step 1: Create the Composite Action Structure
Create a new directory `.github/actions/create-release-tag/` in your repository. This will contain your custom composite action for creating release tags.

### Step 2: Define the Action Metadata
Create an `action.yml` file in the `.github/actions/create-release-tag/` directory with the following specifications:

1. **Action Metadata:**
   - Name: "Create Release Tag"
   - Description: "Creates a Git tag for release deployments"
   - Author: Your name or organization

2. **Inputs:**
   - `tag-name`: (required) The name of the tag to create
   - `commit-sha`: (required) The commit SHA to tag
   - `tag-message`: (optional) Custom message for the tag (default: "Release tag created by GitHub Actions")
   - `github-token`: (required) GitHub token for API access

3. **Outputs:**
   - `tag-sha`: The SHA of the created tag object
   - `tag-url`: The URL of the created tag

### Step 3: Implement the Composite Action Steps
In the same `action.yml` file, implement the composite action steps that:

1. Validate the inputs (check that tag-name and commit-sha are provided)
2. Create the tag object using the GitHub REST API
3. Create the tag reference
4. Set the outputs with the tag information
5. Provide helpful log messages throughout the process

### Step 4: Update the Reusable Workflow
Modify your reusable deployment workflow from Exercise 12 to use the new composite action instead of the inline tagging steps:

1. Replace the "Create Release Tag" step with a call to your composite action
2. Pass the appropriate inputs to the action
3. Use the action's outputs if needed

### Step 5: Test the Composite Action
Create a test workflow that demonstrates the composite action working independently:

1. Create `.github/workflows/test-composite-action.yml`
2. Add a manual trigger (`workflow_dispatch`)
3. Include inputs for tag name and target commit
4. Use your composite action to create a tag
5. Display the action outputs

### Step 6: Advanced Features (Optional)
Enhance your composite action with additional features:

1. Add input validation using shell scripting
2. Support for creating annotated vs lightweight tags
3. Error handling and meaningful error messages
4. Conditional logic based on inputs

## Key Concepts

### Composite Action Structure
```yaml
name: 'My Composite Action'
description: 'Description of what this action does'
inputs:
  my-input:
    description: 'Description of the input'
    required: true
    default: 'default-value'
outputs:
  my-output:
    description: 'Description of the output'
    value: ${{ steps.step-id.outputs.value }}
runs:
  using: 'composite'
  steps:
    - name: Do something
      shell: bash
      run: echo "Hello from composite action"
```

### Using Composite Actions
```yaml
- name: Use my composite action
  uses: ./.github/actions/my-action
  with:
    my-input: 'some-value'
    github-token: ${{ secrets.GITHUB_TOKEN }}
```

### Input and Output Handling
- Inputs are accessed via `${{ inputs.input-name }}`
- Outputs are set using `echo "name=value" >> $GITHUB_OUTPUT`
- All steps must specify a `shell` when using `run`

### Referencing Actions
When using actions in your workflows, you can reference them in several ways:
- Local actions: `./.github/actions/action-name`
- Repository actions: `owner/repo@ref`

When referencing actions from a different repository, the repository usually must be publicly available (required if action should be listed in the GitHub Marketplace). However, you can also use private actions within your organization or enterprise by allowing GitHub Actions to access the action's repository. To do so, go to the repository settings, navigate to "Actions" > "General", and under "Access", select "Accessible from repositories in the '{your organization}' organization" or "Accessible from repositories in the '{your enterprise}' enterprise".

## Expected Files
After completing this exercise, you should have:
- `.github/actions/create-release-tag/action.yml` - The composite action definition
- `.github/workflows/reusable-deploy.yml` - Updated to use the composite action
- `.github/workflows/test-composite-action.yml` - Test workflow for the composite action

## Tips
- Keep composite actions focused on a single responsibility
- Use clear, descriptive names for inputs and outputs
- Add comprehensive descriptions to help users understand the action
- Include input validation to provide helpful error messages
- Test your actions thoroughly with different input combinations
- Consider making your actions available across your organization

## Verification
To verify your solution works:
1. Run the test workflow and confirm a tag is created
2. Check that the original deployment workflow still works
3. Verify that the composite action outputs are properly set
4. Test with different input combinations
5. Ensure error handling works correctly

## Security Considerations
- Be careful with token permissions and scoping
- Validate inputs to prevent injection attacks
- Don't log sensitive information
- Use the principle of least privilege for tokens

## Next Steps
After completing this exercise, you'll have hands-on experience with composite actions and know how to share custom actions within your organization or enterprise. In the next exercise, you'll learn how to access resources in other repositories, which also helps accessing custom actions in repositories that are neither public nor do allow general access for GitHub Actions.
