# user-management-api

### ✍️ Activity 1: Writing and Enhancing API Code with Copilot

GitHub Copilot helped me quickly scaffold the structure for my CRUD API. I then enhanced the API by prompting GitHub Copilot to include validation checks, making the code more robust and reliable.

### 🐞 Activity 2: Debugging API Code with Copilot

When I asked GitHub Copilot to identify anything I might have missed—such as unhandled exceptions—it raised the issue of thread safety. After reviewing its suggestions, I implemented the solution line by line, taking time to understand each change GitHub Copilot proposed.

### ⚙️ Activity 3: Implementing and Managing Middleware with Copilot

![Debugging](https://github.com/user-attachments/assets/adea6c8d-a13a-4321-908d-bdb84e9750f6)

I encountered a conflict between my logging middleware and error-handling middleware. GitHub Copilot suggested wrapping the logging logic in a `try...finally` block to ensure the response body stream is always restored. After applying this fix and running some tests, the issue was resolved.

Initially, I was confused because I had registered the middleware in the correct order. GitHub Copilot explained that without a finally block, the logging middleware could "hijack" the response stream, preventing the error-handling middleware from sending a proper error response. The finally block ensures the original stream is restored even if an exception occurs, allowing error handling to function correctly.

**Tech stack**: .NET, Visual Studio Code, C# Dev Kit, SonarQube, GitHub Copilot
