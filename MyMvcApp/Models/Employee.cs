using System.ComponentModel.DataAnnotations;

namespace MyMvcApp.Models;

public class Employee
{
    public int? Id { get; set; }

    [Required(ErrorMessage = "Full Name is required")]
    public string? FullName { get; set; }


    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string? Email { get; set; }


    public string? Department { get; set; }


    [Range(0, double.MaxValue, ErrorMessage = "Salary must be greater than 0")]
    public decimal? Salary { get; set; }


    public DateTime? HireDate { get; set; }

    public bool IsActive { get; set; }

    public Employee()
    {
    }
}