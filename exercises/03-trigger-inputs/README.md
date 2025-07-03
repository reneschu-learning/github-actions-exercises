# Exercise 3: Trigger Inputs

## Objective
Learn how to create workflows that accept inputs when triggered manually, allowing for dynamic behavior based on user input.

## Instructions

1. **Add workflow inputs**: Modify your workflow from Exercise 2 to accept inputs:
   - Add a `name` input (required) with description "Your name for personalized greeting"
   - Add a `greeting` input (optional) with description "Custom greeting message" and default value "Hello"

2. **Use inputs in workflow**: Modify the workflow to:
   - Use the `greeting` and `name` inputs to create a personalized message
   - Still display the context information from Exercise 2

3. **Test with different inputs**: Try running the workflow with:
   - Just the required `name` input
   - Both `name` and `greeting` inputs
   - Different greeting messages

## Key Concepts
- Workflow inputs using `workflow_dispatch.inputs`
- Input types, descriptions, and default values
- Required vs optional inputs
- Accessing inputs using `github.event.inputs.input_name`

## Expected Output
```
Hello Alice!
Triggered by: [your-username]
Repository: [owner/repo-name]
Reference: refs/heads/main
```

Or with custom greeting:
```
Good morning Alice!
Triggered by: [your-username]
Repository: [owner/repo-name]  
Reference: refs/heads/main
```

## Hints
- Define inputs under `on.workflow_dispatch.inputs`
- Each input can have properties: `description`, `required`, `default`, `type`
- Access inputs using `${{ github.event.inputs.input_name }}`
- The `type` can be `string`, `boolean`, `choice`, or `environment`

## Security Considerations
This workflow is susceptible to script injection because the inputs are directly used in the output. What happens if you set the `name` input to `"; ls -Rla ~; echo "`? 😲 Try it out and see how the workflow behaves. What if we used something like `"; rm -rf /; echo"`? 🤯 We will fix this security issue in the next exercise.

## Solution
If you get stuck, check the [solution](../../solutions/03-trigger-inputs/) directory for a working example.
