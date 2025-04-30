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
        var user = context.User;
        
        if (context.Request.Path == "/" && user.Identity is { IsAuthenticated: true })
        {
            if (user.IsInRole("Employee"))
            {
                context.Response.Redirect("/employees/employeeindex");
                return;
            }
        }

        await _next(context);
    }
}
