# MyMvcApp

## Overview

This project is an ASP.NET Core MVC application built with .NET 7.0. It is an employee management system using Entity Framework Core with a SQLite database and provides both MVC views and REST API endpoints for managing employee data.

## What was implemented

- Configured an ASP.NET Core MVC project with controllers, views, static files, and routing.
- Added Entity Framework Core support using `Microsoft.EntityFrameworkCore` and `Microsoft.EntityFrameworkCore.Sqlite`.
- Created an `Employee` data model with validation attributes (`Required`, `EmailAddress`, `Range`).
- Implemented `AppDbContext` for SQLite database access.
- Built RESTful API endpoints for employee CRUD operations and search functionality.
- Added global exception handling middleware for consistent JSON error responses.
- Integrated Swagger API documentation in development mode.
- Added a Dockerfile to build and run the application in a container.
- Fixed build issues by removing the invalid `Swashbuckle.AspNetCore` namespace import from `Program.cs`.

## Project structure

- `MyMvcApp/Program.cs`
  - Configures MVC services and Entity Framework Core.
  - Registers the SQLite connection using `DefaultConnection`.
  - Adds Swagger generation and enables Swagger UI in development.
  - Registers custom global exception middleware.
  - Defines the default MVC route.

- `MyMvcApp/Controllers/HomeController.cs`
  - Contains basic MVC actions for `Index`, `Privacy`, and `Error`.

- `MyMvcApp/Controllers/EmployeeController.cs`
  - Implements REST API endpoints under `/api/employee`.
  - Supports create, read, update, delete, and search operations.
  - Throws exceptions for invalid input and missing resources so the middleware can handle errors consistently.

- `MyMvcApp/Middleware/ExceptionMiddleware.cs`
  - Catches unhandled exceptions globally.
  - Logs exception details.
  - Returns JSON responses with appropriate HTTP status codes.

- `MyMvcApp/Models/Employee.cs`
  - Defines the `Employee` entity with properties like `FullName`, `Email`, `Department`, `Salary`, `HireDate`, and `IsActive`.
  - Includes validation attributes for required data and valid salary values.

- `MyMvcApp/Models/AppDBContext.cs`
  - Configures the EF Core `DbContext`.
  - Exposes a `DbSet<Employee>` for database operations.

- `MyMvcApp/appsettings.json`
  - Contains application logging settings and the SQLite connection string: `Data Source=employees.db`.

- `MyMvcApp/MyMvcApp.csproj`
  - Targets `.NET 7.0`.
  - Includes package references for `Swashbuckle.AspNetCore`, EF Core, SQLite provider, and EF Core tools.

- `MyMvcApp/Dockerfile`
  - Builds the app with the .NET SDK.
  - Publishes the app and runs it with the ASP.NET Core runtime.

## API endpoints

- `POST /api/employee`
  - Creates a new employee.
  - Validates required fields and email format.
  - Throws an exception if the email already exists.

- `GET /api/employee`
  - Retrieves all employees.

- `GET /api/employee/id/{id}`
  - Retrieves a single employee by ID.
  - Returns a JSON error when the employee is not found.

- `PUT /api/employee/id/{id}`
  - Updates an employee's name and department.
  - Validates input and returns a JSON error for missing or invalid data.

- `DELETE /api/employee/id/{id}`
  - Deletes an employee by ID.
  - Returns a JSON error if the employee does not exist.

- `GET /api/employee/search/name/{name}`
  - Searches employees by full name and returns sorted results.

- `GET /api/employee/search/department/{department}`
  - Searches employees by department and returns sorted results.

## Development notes

- The application exposes Swagger UI only in development mode for API testing.
- Global exception middleware returns JSON error responses with status codes like `400`, `404`, and `500`.
- Static files, HTTPS redirection, and routing are enabled.
- The default MVC route points to `Home/Index`.

## How to run

1. Open the `MyMvcApp` folder in your terminal.
2. Run `dotnet restore` to install dependencies.
3. Run `dotnet build` to compile the project.
4. Run `dotnet run` to start the application.
5. Open the browser at `https://localhost:5001` or `http://localhost:5000`.

## Docker run

1. Build the Docker image from the `MyMvcApp` folder:
   - `docker build -t mymvcapp .`
2. Run the container:
   - `docker run -p 8080:80 mymvcapp`
3. Open `http://localhost:8080`.

## What I accomplished

- Built a working ASP.NET Core MVC application with Entity Framework Core and SQLite.
- Implemented RESTful API endpoints and search capabilities.
- Added global exception handling middleware for consistent JSON errors.
- Integrated Swagger for development API documentation.
- Added Docker support for containerized deployment.
- Fixed Swagger build issues by cleaning up the `Program.cs` imports.
