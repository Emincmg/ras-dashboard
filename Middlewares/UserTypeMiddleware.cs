namespace RasDashboard.Middlewares;

public class UserTypeMiddleware
{
    private readonly RequestDelegate _next;

    public UserTypeMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Path == "/")
        {
            var user = context.User;
            var userType = user.IsInRole("Admin") ? "Admin" : user.IsInRole("User") ? "User" : "Guest";

            if (userType == "Admin")
            {
                context.Response.Redirect("/");
            }
            else if (userType == "/authentication/signin")
            {
                context.Response.Redirect("/employees/employeeindex");
            }
            else
            {
                context.Response.Redirect("/authentication/signin");
            }
        }
        else
        {
            await _next(context);
        }
    }
}