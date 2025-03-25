using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RhsDashboard.Models;

namespace RhsDashboard.Controllers;

public class AccountController : Controller
{
    private readonly SignInManager<Employee> _signInManager;

    public AccountController(SignInManager<Employee> signInManager)
    {
        _signInManager = signInManager;
    }
    
    [Route("Account/Logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToPage("/Authentication/Signin");
    }
}