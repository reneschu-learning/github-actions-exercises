# GitHub Actions Exercise Repository
This repository contains a series of exercises designed to help you learn and practice GitHub Actions. Each exercise is contained within its own directory within the [exercises](./exercises/) directory, with a `README.md` file that provides instructions and context. Some exercises build on previous ones, so it's recommended to complete them in order. The repository also includes a [solutions](./solutions/) directory that contains example solutions for each exercise. You can refer to these solutions if you get stuck or want to compare your solution with an example.

## Prerequisites
To complete the exercises in this repository, you should have the following prerequisites:
- A GitHub account: You will need a GitHub account to create repositories and run workflows.
  - A personal account is preferred as it allows more freedom without running into enterprise- or organization-level restrictions.
- Basic knowledge of Git: Familiarity with Git commands such as `clone`, `commit`, `push`, and `pull` will be helpful.
- Basic understanding of YAML: GitHub Actions workflows are defined in YAML files, so a basic understanding of YAML syntax is required.
- Familiarity with GitHub: You should be comfortable navigating GitHub, creating repositories, and managing issues and pull requests.
- A code editor: You can use any code editor of your choice to edit the workflow files and read the instructions in the `README.md` files.
- Optional: Familiarity with the command line or terminal, as some exercises may involve running commands in a terminal.

## Getting Started
To get started with the exercises, follow these steps:

1. **Clone the Repository**: Use the following command to clone the repository to your local machine:
   ```
   git clone https://github.com/reneschu-learning/github-actions-exercises.git
   ```

2. **Navigate to an Exercise Directory**: Each exercise is located in its own directory. Navigate to the directory of the exercise you want to work on:
   ```
   cd github-actions-exercises/01-hello-world
   ```

3. **Follow the Instructions**: Open the `README.md` file in the exercise directory and follow the instructions to complete the exercise.

# Table of Contents
## Foundational Exercises
- [Exercise 1: Hello World](./exercises/01-hello-world/README.md) ([Solution](./solutions/01-hello-world/))  
  This exercise introduces you to GitHub Actions by creating a simple workflow that prints "Hello, World!" to the console. It introduces the basic structure of a GitHub Actions workflow file and how to trigger it manually.
- [Exercise 2: Accessing Context](./exercises/02-accessing-context/README.md) ([Solution](./solutions/02-accessing-context/))  
  In this exercise, you will learn how to access the context and use it in your workflows. You will modify the "Hello, World!" workflow from exercise 1 to use the GitHub context and show information about the actor (i.e., the user who triggered the workflow).
- [Exercise 3: Trigger Inputs](./exercises/03-trigger-inputs/README.md) ([Solution](./solutions/03-trigger-inputs/))
  In this exercise, you will learn how to create a workflow that accepts inputs when triggered manually. You will modify the "Hello, World!" workflow from exercise 2 to accept a name input and print a personalized greeting.
- [Exercise 4: Issue Trigger](./exercises/04-issue-trigger/README.md) ([Solution](./solutions/04-issue-trigger/))
  This exercise introduces you to triggering workflows based on GitHub issues. You will modify the "Hello, World!" workflow from exercise 3 to also run when an issue is opened and print the issue title and body to the console. This exercise will also dive into possible security considerations when using context and inputs in workflows.
- [Exercise 5: Conditions](./exercises/05-conditions/README.md) ([Solution](./solutions/05-conditions/))
  In this exercise, you will learn how to use conditions to control execution of steps. You will modify the "Hello, World!" workflow from exercise 4 so that it doesn't fail when it is not triggered by an issue event. You will also add another trigger (cron) and react to it conditionally.
- [Exercise 6: Using Workflow Token](./exercises/06-workflow-token/README.md) ([Solution](./solutions/06-workflow-token/))
  This exercise introduces you to the workflow token, which is a special token that is automatically created for each workflow run. You will learn how to use the workflow token to authenticate API requests and perform actions on behalf of the workflow. This exercise also introduces the [GitHub CLI](https://cli.github.com/) (`gh`) and shows how to use it in workflows.
- [Exercise 7: Multiple Jobs](./exercises/07-multiple-jobs/README.md) ([Solution](./solutions/07-multiple-jobs/))
  This exercise introduces you to workflows with multiple jobs. It shows how to run multiple jobs in parallel, how to set dependencies between jobs, and how to use job-level conditions. In addition, we will introduce the matrix strategy as well as job outputs and artifacts to pass data between jobs. This exercise also introduces the first two actions `actions/upload-artifact` and `actions/download-artifact` to handle artifacts.
- [Exercise 8: Environments, Variables, and Secrets](./exercises/08-environments-variables-secrets/README.md) ([Solution](./solutions/08-environments-variables-secrets/))
  In this exercise, you will learn how to use environments, variables, and secrets in your workflows. You will create a workflow that uses an environment to control access to a job and uses secrets to store sensitive information. You will also learn how to use variables to store reusable values in your workflows.

## Intermediate Exercises
- [Exercise 9: Full CI/CD Pipeline](./exercises/09-full-ci-cd-pipeline/README.md) ([Solution](./solutions/09-full-ci-cd-pipeline/))
  This exercise brings together everything you've learned so far to create a complete CI/CD pipeline. You will create a workflow that builds, tests, and deploys a sample application. You will also learn about new triggers (`push`, `pull_request`) and start using actions like `actions/checkout` to check out the code or `actions/setup-dotnet` to set up the .NET environment. You can use the simple .NET console application provided in the [sample-app](./exercises/09-full-ci-cd-pipeline/sample-app/) directory for this exercise.
- [Exercise 10: Simple Workflow with Azure Deployment (Service Principal)](./exercises/10-azure-deployment-sp/README.md) ([Solution](./solutions/10-azure-deployment-sp/))
  In this exercise, you will create a simple workflow for deploying some resources to Azure using a service principal for authentication. You will learn how to create a service principal, configure it in your workflow, and deploy a few resources (resource group, storage account, storage container) to Azure. This exercise also introduces the `azure/login` action to authenticate with Azure.
- [Exercise 11: Simple Workflow with Azure Deployment (OIDC)](./exercises/11-azure-deployment-oidc/README.md) ([Solution](./solutions/11-azure-deployment-oidc/))
  This exercise builds on the previous one by using OIDC authentication to deploy the resources to Azure. You will learn how to configure federated credentials in Azure and use the `azure/login` action with OIDC authentication, which removes the need to store any secrets in your repository.

## Advanced Exercises
- [Exercise 12: Reusable Workflows](./exercises/12-reusable-workflows/README.md) ([Solution](./solutions/12-reusable-workflows/))
  In this exercise, you will learn how to create reusable workflows that can be called from other workflows. You will rewrite the workflow from exercise 9 to reduce duplication by moving parts of it to a reusable workflow.
- [Exercise 13: Custom Composite Actions](./exercises/13-custom-composite-actions/README.md) ([Solution](./solutions/13-custom-composite-actions/))
  This exercise introduces you to creating custom composite actions, which is another way to make parts of your workflows reusable without introducing additional jobs. You will create a composite action that encapsulates the tagging step from the reusable workflow of exercise 12 and can be reused in multiple workflows. You will also learn how to use inputs and outputs in composite actions.
- [Exercise 14: Accessing External Repositories](./exercises/14-accessing-external-repositories/README.md) ([Solution](./solutions/14-accessing-external-repositories/))
  This exercise introduces you to accessing external repositories in your workflows using GitHub Apps. You will learn how to create a GitHub App with a private key, install it in an organization, store the private key as a secret, and use the `actions/create-github-app-token@v1` action to generate tokens for accessing external repositories. You will create a workflow that uses the GitHub App to create issues in different repositories.

# Contributing
If you would like to contribute to this repository, please follow these steps:

1. **Fork the Repository**: Click the "Fork" button in the top right corner of the repository page on GitHub.

2. **Create a New Branch**: Create a new branch for your changes:
   ```
   git checkout -b my-feature-branch
   ```

3. **Make Your Changes**: Make the necessary changes to the code or documentation.

4. **Commit Your Changes**: Commit your changes with a descriptive commit message:
   ```
   git commit -m "Add my feature"
   ```

5. **Push Your Changes**: Push your changes to your forked repository:
   ```
   git push origin my-feature-branch
   ```

6. **Create a Pull Request**: Go to the original repository and create a pull request from your forked repository.

## License
This repository is licensed under the MIT License. See the [LICENSE](LICENSE) file for more information.