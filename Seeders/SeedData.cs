using Microsoft.AspNetCore.Identity;
using RasDashboard.Models;

namespace RasDashboard.Seeders;

public class SeedData
{
     public static async Task SeedUsersAsync(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<Employee>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        
        if (!await roleManager.RoleExistsAsync("Employee"))
        {
            await roleManager.CreateAsync(new IdentityRole("Employee"));
        }

        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        }
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
        
        var basicEmployees = new[]
        {
            new { Username = "AhmetAkdogan", Email = "ahmet-akdogan@rasdashboard.com", Name = "Ahmet Akdoğan" },
            new { Username = "AykutTürkan", Email = "aykut-turkan@rasdashboard.com", Name = "Aykut Türkan" },
            new { Username = "BirgulAkbas", Email = "birgul-akbas@rasdashboard.com", Name = "Birgül Akbaş" },
            new { Username = "EjderAkdogan", Email = "ejder-akdogan@rasdashboard.com", Name = "Ejder Akdoğan" },
            new { Username = "EmreYildiz", Email = "emre-yildiz@rasdashboard.com", Name = "Emre Yıldız" },
            new { Username = "MedineKubilay", Email = "medine-kubilay@rasdashboard.com", Name = "Medine Kubilay" },
            new { Username = "MuazBabur", Email = "muaz-babur@rasdashboard.com", Name = "Muaz Babur" },
            new { Username = "SedatKaraca", Email = "sedat-karaca@rasdashboard.com", Name = "Sedat Karaca" },
            new { Username = "YakupAltun", Email = "yakup-altun@rasdashboard.com", Name = "Yakup Altun" },
        };

        foreach (var e in basicEmployees)
        {
            var existingUser = await userManager.FindByEmailAsync(e.Email);
            if (existingUser == null)
            {
                var employee = new Employee
                {
                    UserName = e.Username,
                    Email = e.Email,
                    NormalizedEmail = e.Email.ToUpper(),
                    Name = e.Name,
                    Position = "Employee",
                    Department = "General",
                    EmailConfirmed = true
                };

                var password = $"{e.Username}RAS123!";

                var result = await userManager.CreateAsync(employee, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(employee, "Employee");
                }
                else
                {
                    Console.WriteLine($"Failed to create user {e.Email}: {string.Join(", ", result.Errors.Select(er => er.Description))}");
                }
            }
        }
    }
}