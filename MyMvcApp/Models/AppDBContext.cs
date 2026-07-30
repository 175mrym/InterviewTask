using Microsoft.EntityFrameworkCore;

namespace MyMvcApp.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {

    }

    public DbSet<Employee> employees { get; set; }
}