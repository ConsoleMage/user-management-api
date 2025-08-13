# user-management-api

This is the peer-graded assignment for "Back-End Development with .NET," the fifth course in a 12-course series in the Microsoft Full-Stack Developer Professional Certificate program.

A project template for creating a RESTful Web API using ASP.NET Core controllers or minimal APIs, with optional support for OpenAPI and authentication.

## Introduction

You’ve been hired by TechHive Solutions to develop a User Management API for their internal tools. The HR and IT departments need an API that allows them to create, update, retrieve, and delete user records efficiently. Your task is to build the core functionality of the API, using Microsoft Copilot to scaffold, enhance, and test the code.

## Activity 1: Writing and Enhancing API Code with Copilot

(5pts) Did you create a GitHub repository for your project?
> Yes. You can view it at https://github.com/ConsoleMage/user-management-api.

(5pts) Does your code include CRUD endpoints for managing users like GET, POST, PUT, and DELETE?
> Yes.

(5pts) Does your code include additional functionality like validation to process only valid user data? 

> Yes. Null or empty names are not allowed, and names must contain only alphabetic characters.

## Activity 2: Debugging API Code with Copilot

![Debugging](https://github.com/user-attachments/assets/adea6c8d-a13a-4321-908d-bdb84e9750f6)

(5pts) Did you use Copilot to debug your code?

> Yes. The error handling and logging middleware had an issue where the original response stream was not properly restored if an exception occurred. This was fixed by using a `try...finally` block to ensure the original stream is always restored, preventing it from being disposed unexpectedly.

## Activity 3: Implementing and Managing Middleware with Copilot

(5pts) Did you implement middleware into your project, such as logging or authentication middleware? 

> Yes. The code includes custom middleware for error handling and request/response logging.

**Tech Stack**: ASP.NET Core, Visual Studio Code, C# Dev Kit, REST Client, SonarQube for IDE, GitHub Copilot
