// (5pts) Did you create a GitHub repository for your project?
// https://github.com/ConsoleMage/user-management-api

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UserManagementAPI.Middleware;
using UserManagementAPI.Models;

namespace UserManagementAPI
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://your-auth-server.com";
                    options.Audience = "your-api-name";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "https://your-auth-server.com",
                        ValidAudience = "your-api-name",
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes("your-very-secret-key"))
                    };
                });

            builder.Services.AddAuthorization();

            var app = builder.Build();

            // (5pts) Did you use Copilot to debug your code?
            // The error handling and logging middleware had an issue where the original 
            // response stream was not properly restored if an exception occurred. 
            // This was fixed by using a try...finally block to ensure the original stream 
            // is always restored, preventing it from being disposed unexpectedly.

            // (5pts) Did you implement middleware into your project, such as logging or 
            // authentication middleware? 
            // Yes. The code includes custom middleware for error handling and request/response logging.
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseMiddleware<RequestResponseLoggingMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapGet("/", () => "Hello World!");

            var users = new List<User>
            {
                new() { Id = 1, Name = "Alice" },
                new() { Id = 2, Name = "Bob" }
            };
            object usersLock = new();

            // (5pts) Does your code include CRUD endpoints for managing users like 
            // GET, POST, PUT, and DELETE?
            // Yes.
            app.MapGet("/users", () =>
            {
                lock (usersLock)
                {
                    return Results.Ok(users.ToList());
                }
            })
            .WithName("GetUsers");

            app.MapGet("/users/{id}", (int id) =>
            {
                lock (usersLock)
                {
                    var user = users.FirstOrDefault(u => u.Id == id);
                    return user is not null ? Results.Ok(user) : Results.NotFound("No matching user found with this ID.");
                }
            })
            .WithName("GetUserById");

            // (5pts) Does your code include additional functionality like validation to process only valid user data? 
            // Yes. Null or empty names are not allowed, and names must contain only alphabetic characters.
            app.MapPost("/users", (User user) =>
            {
                if (string.IsNullOrWhiteSpace(user.Name))
                    return Results.BadRequest("User name is required.");
                if (!user.Name.All(char.IsLetter))
                    return Results.BadRequest("User name must contain only alphabetic characters.");

                lock (usersLock)
                {
                    user.Id = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1;
                    users.Add(user);
                }
                return Results.Created($"/users/{user.Id}", user);
            })
            .WithName("CreateUser");

            app.MapPut("/users/{id}", (int id, User updatedUser) =>
            {
                lock (usersLock)
                {
                    var user = users.FirstOrDefault(u => u.Id == id);
                    if (user is null) return Results.NotFound("No matching user found with this ID.");
                    user.Name = updatedUser.Name;
                    return Results.Ok(user);
                }
            })
            .WithName("UpdateUser");

            app.MapDelete("/users/{id}", (int id) =>
            {
                lock (usersLock)
                {
                    var user = users.FirstOrDefault(u => u.Id == id);
                    if (user is null) return Results.NotFound("No matching user found with this ID.");
                    users.Remove(user);
                    return Results.NoContent();
                }
            })
            .WithName("DeleteUser");

            app.MapGet("/simulate-error", () =>
            {
                throw new InvalidOperationException("Simulated server error");
            });

            await app.RunAsync();
        }
    }
}

