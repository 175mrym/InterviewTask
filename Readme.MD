# MyMvcApp

## Overview

MyMvcApp is a small ASP.NET Core MVC application built with .NET 7.0. It combines a simple Bootstrap-based UI with an employee management API and stores data in SQLite.

## What this project includes

- A basic employee dashboard page with a form and employee list
- A REST API for creating, reading, updating, deleting, and searching employees
- Entity Framework Core with SQLite persistence
- Basic validation and global exception handling
- Swagger support for API testing during development

## Main project structure

- Controllers: handles the MVC home page and employee API routes
- Models: contains the employee model and EF Core database context
- Views: contains the Razor pages and Bootstrap UI
- Middleware: includes custom global exception handling
- wwwroot: contains static CSS and JavaScript assets

## Employee features

Users can:

- Add new employees
- View employees in a table
- Delete employees
- Search employees by name or department

## API endpoints

- GET /api/employee - get all employees
- POST /api/employee - create an employee
- GET /api/employee/id/{id} - get an employee by ID
- PUT /api/employee/id/{id} - update an employee
- DELETE /api/employee/id/{id} - delete an employee
- GET /api/employee/search/name/{name} - search by name
- GET /api/employee/search/department/{department} - search by department

## Technologies used

- ASP.NET Core MVC
- Entity Framework Core
- SQLite
- Bootstrap
- Swagger / Swashbuckle
