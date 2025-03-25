using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RhsDashboard.Interfaces;
using RhsDashboard.Models;

namespace RhsDashboard.Areas.Identity.Data;

public class RhsDashboardContext : IdentityDbContext<Employee>
{
    public RhsDashboardContext(DbContextOptions<RhsDashboardContext> options) : base(options) { }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<TaskItem> TaskItems { get; set; }
    public DbSet<Room> Rooms { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Id = "2", Name = "User", NormalizedName = "USER" }
        );
        
        builder.Entity<Employee>().HasData(
            new Employee
            {
                Id = "1001",
                UserName = "EminComoglu",
                Email = "em1.16@odsol-mail.com",
                Name = "Emin Çomoğlu",
                Position = "Lead Developer",
                Department = "WEB"
            }
        );
        
        var employees = new List<Employee>();
        for (int i = 1; i <= 10; i++)
        {
            employees.Add(new Employee
            {
                UserName = $"Employee{i}",
                Email = $"employee{i}@example.com",
                Name = $"Employee {i}",
                Position = "Staff",
                Department = "General"
            });
        }

        builder.Entity<Employee>().HasData(employees);
    }
}
