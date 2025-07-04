# user-management-api

✍️ Activity 1: Writing and Enhancing API Code with Copilot
GitHub Copilot helped me quickly scaffold the structure for my CRUD API. I then enhanced the API by prompting Copilot to include validation checks, making the code more robust and reliable.

🐞 Activity 2: Debugging API Code with Copilot
When I asked GitHub Copilot to identify anything I might have missed—such as unhandled exceptions—it raised the issue of thread safety. After reviewing its suggestions, I implemented the solution line by line, taking time to understand each change Copilot proposed.

![Middleware](https://github.com/user-attachments/assets/09f64ed0-a89e-48f8-8ab5-148e7f44dda7)

⚙️ Activity 3: Implementing and Managing Middleware with Microsoft Copilot
I encountered a conflict between my logging middleware and error-handling middleware. GitHub Copilot suggested wrapping the logging logic in a try...finally block to ensure the response body stream is always restored. After applying this fix and running some tests, the issue was resolved.

Initially, I was confused because I had registered the middleware in the correct order. Copilot explained that without a finally block, the logging middleware could "hijack" the response stream, preventing the error-handling middleware from sending a proper error response. The finally block ensures the original stream is restored even if an exception occurs, allowing error handling to function correctly.
