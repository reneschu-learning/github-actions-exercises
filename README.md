# GitHub Actions Exercise Repository
This repository contains a series of exercises designed to help you learn and practice GitHub Actions. Each exercise is contained within its own directory within the [exercises](./exercises/) directory, with a `README.md` file that provides instructions and context. Some exercises build on previous ones, so it's recommended to complete them in order. The repository also includes a [solutions](./solutions/) directory that contains example solutions for each exercise. You can refer to these solutions if you get stuck or want to compare your solution with an example.

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
- [Exercise 6: Multiple Jobs](./exercises/06-multiple-jobs/README.md) ([Solution](./solutions/06-multiple-jobs/))
  This exercise introduces you to workflows with multiple jobs. It shows how to run multiple jobs in parallel, how to set dependencies between jobs, and how to use job-level conditions. In addition, we will introduce the matrix strategy as well as job outputs and artifacts to pass data between jobs. This exercise also introduces the first two actions `actions/upload-artifact` and `actions/download-artifact` to handle artifacts.

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