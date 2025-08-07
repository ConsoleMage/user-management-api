# user-management-api

This is the peer-graded assignment for "Back-End Development with .NET," the fifth course in a 12-course series in the Microsoft Full-Stack Developer Professional Certificate program.

A project template for creating a RESTful Web API using ASP.NET Core controllers or minimal APIs, with optional support for OpenAPI and authentication.

## Introduction

You’ve been hired by TechHive Solutions to develop a User Management API for their internal tools. The HR and IT departments need an API that allows them to create, update, retrieve, and delete user records efficiently. Your task is to build the core functionality of the API, using Microsoft Copilot to scaffold, enhance, and test the code.

## Activity 1: Writing and Enhancing API Code with Copilot

In this activity, you will use Copilot to write and enhance API code for a User Management API. This project will give you practice writing code yourself and using Copilot to help. You’ll use Copilot to generate code and then enhance and test that code. 

This is the first of three activities in which you will develop and code a back-end API project. The final output will be a working API project that you can use to demonstrate your understanding of back-end development.

GitHub Copilot helped me quickly scaffold the structure for my CRUD API. I then enhanced the API by prompting GitHub Copilot to include validation checks, making the code more robust and reliable.

## Activity 2: Debugging API Code with Copilot

In this activity, you will use Copilot to debug the code you’ve started for your API project. This project will give you practice reviewing code, debugging, and implementing fixes. You’ll use Copilot to discover issues and suggest changes to improve your code.

This is the second of three activities in which you will develop and code a back-end API project. The final output will be a working API project that you can use to demonstrate your understanding of back-end development.

When I asked GitHub Copilot to identify anything I might have missed, such as unhandled exceptions, it raised the issue of thread safety. After reviewing its suggestions, I implemented the solution line by line, taking time to understand each change GitHub Copilot proposed.

## Activity 3: Implementing and Managing Middleware with Copilot

In this activity, you will use Copilot to create middleware for logging, authentication, and error handling and configure the middleware pipeline. This project will give you practice working with middleware, from implementation to management. Copilot can help with every step of this process. 

This is the last of three activities in which you will develop and code a back-end API project. The final output will be a working API project that you can use to demonstrate your understanding of back-end development.

![Debugging](https://github.com/user-attachments/assets/adea6c8d-a13a-4321-908d-bdb84e9750f6)

I encountered a conflict between my logging middleware and error-handling middleware. GitHub Copilot suggested wrapping the logging logic in a `try...finally` block to ensure the response body stream is always restored. After applying this fix and running some tests, the issue was resolved.

Initially, I was confused because I had registered the middleware in the correct order. GitHub Copilot explained that without a finally block, the logging middleware could "hijack" the response stream, preventing the error-handling middleware from sending a proper error response. The finally block ensures the original stream is restored even if an exception occurs, allowing error handling to function correctly.

**Tech Stack**: ASP.NET Core, Visual Studio Code, C# Dev Kit, REST Client, SonarQube for IDE, GitHub Copilot
