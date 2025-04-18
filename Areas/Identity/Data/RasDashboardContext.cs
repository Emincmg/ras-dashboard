using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using RasDashboard.Interfaces;
using RasDashboard.Models;

namespace RasDashboard.Areas.Identity.Data;

public class RasDashboardContext : IdentityDbContext<Employee>
{
    
    public RasDashboardContext(DbContextOptions<RasDashboardContext> options) : base(options) { }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<TaskItem> TaskItems { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<EmployeeTask> EmployeeTasks { get; set; }
    private readonly IConfiguration _configuration;

    public RasDashboardContext(DbContextOptions<RasDashboardContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
         .UseSeeding((context, serviceProvider) =>
        {
            var userManager = context.GetService<UserManager<Employee>>();

            // Seed IdentityRole data
            if (!context.Set<IdentityRole>().Any())
            {
                context.Set<IdentityRole>().AddRange(
                    new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                    new IdentityRole { Id = "2", Name = "Employee", NormalizedName = "EMPLOYEE" }
                );
                context.SaveChanges();
            }

            // Seed Employee data
            if (!context.Set<Employee>().Any())
            {
                var emin = new Employee
                {
                    UserName = "EminComoglu",
                    Email = "em1.16@odsol-mail.com",
                    NormalizedEmail = "EM1.16@ODSOL-MAIL.COM",
                    Name = "Emin Çomoğlu",
                    Position = "Lead Developer",
                    Department = "WEB"
                };
                userManager.CreateAsync(emin, "Password123!").Wait();
                userManager.AddToRoleAsync(emin, "Admin").Wait();

                for (int i = 1; i <= 10; i++)
                {
                    var employee = new Employee
                    {
                        UserName = $"Employee{i}",
                        Email = $"employee{i}@example.com",
                        NormalizedEmail = $"EMPLOYEE{i}@EXAMPLE.COM",
                        Name = $"Employee {i}",
                        Position = "Employee",
                        Department = "General"
                    };
                    userManager.CreateAsync(employee, "Password123!").Wait();
                    userManager.AddToRoleAsync(employee, "Employee").Wait();
                }
            }

            // Seed EmployeeTask data
            if (!context.Set<EmployeeTask>().Any())
            {
                context.Set<EmployeeTask>().AddRange(
                    new EmployeeTask { Name = "Fast Check", Description = "To be clarified later." },
                    new EmployeeTask { Name = "Cleaning Check", Description = "To be clarified later." },
                    new EmployeeTask { Name = "Detailed Check", Description = "To be clarified later." },
                    new EmployeeTask { Name = "Unexpected Visit", Description = "To be clarified later." },
                    new EmployeeTask { Name = "Thermal Bath Control", Description = "To be clarified later." },
                    new EmployeeTask { Name = "Nuki Battery Change", Description = "To be clarified later." },
                    new EmployeeTask { Name = "Shopping", Description = "To be clarified later." },
                    new EmployeeTask { Name = "Office Work", Description = "To be clarified later." }
                );
                context.SaveChanges();
            }
        })
        .UseAsyncSeeding(async (context, _, cancellationToken) =>
        {
            var userManager = context.GetService<UserManager<Employee>>();

            // Seed IdentityRole data
            if (!await context.Set<IdentityRole>().AnyAsync(cancellationToken))
            {
                await context.Set<IdentityRole>().AddRangeAsync(
                    new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                    new IdentityRole { Id = "2", Name = "Employee", NormalizedName = "EMPLOYEE" }
                );
                await context.SaveChangesAsync(cancellationToken);
            }

            // Seed Employee data
            if (!await context.Set<Employee>().AnyAsync(cancellationToken))
            {
                var emin = new Employee
                {
                    UserName = "EminComoglu",
                    Email = "em1.16@odsol-mail.com",
                    NormalizedEmail = "EM1.16@ODSOL-MAIL.COM",
                    Name = "Emin Çomoğlu",
                    Position = "Lead Developer",
                    Department = "WEB"
                };
                await userManager.CreateAsync(emin, "Password123!");
                await userManager.AddToRoleAsync(emin, "Admin");

                for (int i = 1; i <= 10; i++)
                {
                    var employee = new Employee
                    {
                        UserName = $"Employee{i}",
                        Email = $"employee{i}@example.com",
                        NormalizedEmail = $"EMPLOYEE{i}@EXAMPLE.COM",
                        Name = $"Employee {i}",
                        Position = "Employee",
                        Department = "General"
                    };
                    await userManager.CreateAsync(employee, "Password123!");
                    await userManager.AddToRoleAsync(employee, "Employee");
                }
            }

            // Seed EmployeeTask data
            if (!await context.Set<EmployeeTask>().AnyAsync(cancellationToken))
            {
                await context.Set<EmployeeTask>().AddRangeAsync(
                    new EmployeeTask { Name = "Fast Check", Description = "To be clarified later." },
                    new EmployeeTask { Name = "Cleaning Check", Description = "To be clarified later." },
                    new EmployeeTask { Name = "Detailed Check", Description = "To be clarified later." },
                    new EmployeeTask { Name = "Unexpected Visit", Description = "To be clarified later." },
                    new EmployeeTask { Name = "Thermal Bath Control", Description = "To be clarified later." },
                    new EmployeeTask { Name = "Nuki Battery Change", Description = "To be clarified later." },
                    new EmployeeTask { Name = "Shopping", Description = "To be clarified later." },
                    new EmployeeTask { Name = "Office Work", Description = "To be clarified later." }
                );
                await context.SaveChangesAsync(cancellationToken);
            }
        })
        .EnableSensitiveDataLogging();
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
