using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;
using System.ComponentModel.DataAnnotations;

namespace MyMvcApp.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class EmployeeController : ControllerBase
{
    private readonly AppDbContext ctx;

    public EmployeeController(AppDbContext ctx)
    {
        this.ctx = ctx;
    }

    //create employee action method
    [HttpPost]
    public IActionResult CreateEmployee(Employee employee)
    {
        if (!ModelState.IsValid)
            throw new ArgumentException("Employee data is invalid.");

        ValidateEmployee(employee);

        var existingEmployee = ctx.employees
            .FirstOrDefault(e => e.Email == employee.Email);

        if (existingEmployee != null)
            throw new ArgumentException("Email already exists.");

        ctx.employees.Add(employee);
        ctx.SaveChanges();

        return Ok(employee);
    }

    //get all employees action method
    [HttpGet]
    public IActionResult GetAllEmployees()
    {
        var employeeList = ctx.employees.ToList();
        return Ok(employeeList);
    }

    //get employee by id action method
    [HttpGet("id/{id}")]
    public IActionResult GetEmployeeById(int id)
    {
        var employee = ctx.employees.FirstOrDefault(e => e.Id == id);
        return Ok(employee ?? throw new KeyNotFoundException($"Employee with id {id} not found."));
    }

    //update employee action method
    [HttpPut("id/{id}")]
    public IActionResult UpdateEmployee(int id, Employee updatedEmployee)
    {
        if (!ModelState.IsValid)
            throw new ArgumentException("Updated employee data is invalid.");

        var employee = ctx.employees.FirstOrDefault(e => e.Id == id)
            ?? throw new KeyNotFoundException($"Employee with id {id} not found.");

        employee.FullName = updatedEmployee.FullName;
        employee.Department = updatedEmployee.Department;

        ctx.SaveChanges();
        return Ok(employee);
    }

    //delete employee action method
    [HttpDelete("id/{id}")]
    public IActionResult DeleteEmployee(int id)
    {
        var employee = ctx.employees.FirstOrDefault(e => e.Id == id)
            ?? throw new KeyNotFoundException($"Employee with id {id} not found.");

        ctx.employees.Remove(employee);
        ctx.SaveChanges();

        return Ok("Employee deleted successfully");
    }

    //search employee by name action method sorted by name
    [HttpGet("search/name/{name}")]
    public IActionResult SearchEmployeeByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Search name cannot be empty.");

        var employeeList = ctx.employees
            .Where(e => !string.IsNullOrEmpty(e.FullName) && e.FullName.Contains(name))
            .OrderBy(e => e.FullName)
            .ToList();

        return Ok(employeeList);
    }

    //search employee by department action method sorted by name
    [HttpGet("search/department/{department}")]
    public IActionResult SearchEmployeeByDepartment(string department)
    {
        if (string.IsNullOrWhiteSpace(department))
            throw new ArgumentException("Search department cannot be empty.");

        var employeeList = ctx.employees
            .Where(e => !string.IsNullOrEmpty(e.Department) && e.Department.Contains(department))
            .OrderBy(e => e.FullName)
            .ToList();

        return Ok(employeeList);
    }

    [HttpGet("privacy")]
    public IActionResult Privacy()
    {
        return Ok();
    }

    private static void ValidateEmployee(Employee employee)
    {
        var context = new ValidationContext(employee);
        var results = new List<ValidationResult>();

        if (!Validator.TryValidateObject(employee, context, results, true))
            throw new ArgumentException("Employee entity validation failed.");
    }
}
