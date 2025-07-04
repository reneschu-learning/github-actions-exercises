# Exercise 13 Solution: Custom Composite Actions

## Overview
This solution demonstrates how to create a custom composite action that encapsulates the release tagging functionality from Exercise 12. The composite action provides a reusable way to create Git tags with proper error handling and outputs.

## Files Created

### 1. Composite Action (`.github/actions/create-release-tag/action.yml`)
The main composite action that handles tag creation with:
- Input validation
- GitHub API integration
- Error handling
- Structured outputs

### 2. Updated Reusable Workflow (`reusable-deploy.yml`)
Modified version of the reusable workflow from Exercise 12 that uses the new composite action instead of inline tagging steps.

### 3. Test Workflow (`test-composite-action.yml`)
A standalone workflow to test the composite action independently, demonstrating how to use it in different contexts.

## Key Features

### Composite Action Features
- **Input Validation**: Ensures required inputs are provided
- **Flexible Tag Naming**: Supports custom tag names and messages
- **Error Handling**: Provides meaningful error messages
- **Structured Outputs**: Returns tag SHA and URL for further use
- **API Integration**: Uses GitHub REST API for tag creation

### Benefits Demonstrated
- **Code Reusability**: Tag creation logic can be used in multiple workflows
- **Maintainability**: Changes to tagging logic only need to be made in one place
- **Testability**: Composite action can be tested independently
- **Clarity**: Workflow steps are more readable and focused

## Usage Examples

### In a Workflow
```yaml
- name: Create Release Tag
  uses: ./.github/actions/create-release-tag
  with:
    tag-name: 'v1.0.0'
    commit-sha: ${{ github.sha }}
    tag-message: 'Release v1.0.0'
    github-token: ${{ secrets.GITHUB_TOKEN }}
```

### With Dynamic Tag Names
```yaml
- name: Create Release Tag
  uses: ./.github/actions/create-release-tag
  with:
    tag-name: 'v1.0.${{ github.run_number }}'
    commit-sha: ${{ github.sha }}
    github-token: ${{ secrets.GITHUB_TOKEN }}
```

## Testing
The solution includes comprehensive testing through:
1. Manual testing via the test workflow
2. Integration testing via the updated reusable workflow
3. Error condition testing with invalid inputs

## Extension Ideas
This composite action could be extended with:
- Support for pre-release tags
- Integration with release notes generation
- Support for different tag formats
- Notification capabilities
- Rollback functionality

## Best Practices Demonstrated
- Clear input/output definitions
- Comprehensive error handling
- Meaningful log messages
- Secure token handling
- Modular design principles
