using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using RasDashboard.Interfaces;
using RasDashboard.Models;

namespace RasDashboard.Areas.Identity.Data;

public class RasDashboardContext : IdentityDbContext<Employee>
{
    public RasDashboardContext(DbContextOptions<RasDashboardContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<TaskItem> TaskItems { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<EmployeeTask> EmployeeTasks { get; set; }
    private readonly IConfiguration _configuration;

    public RasDashboardContext(DbContextOptions<RasDashboardContext> options, IConfiguration configuration) :
        base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
            .UseSeeding((context, serviceProvider) =>
            {
                // Seed EmployeeTask data
                if (context.Set<EmployeeTask>().Any()) return;
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
            })
            .UseAsyncSeeding(async (context, _, cancellationToken) =>
            {
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