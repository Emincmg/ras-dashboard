using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RasDashboard.Areas.Identity.Data;
using RasDashboard.Interfaces;
using RasDashboard.Models;
using RasDashboard.Services;
using RasDashboard.FluentValidators;
using RasDashboard.Middlewares;
using RasDashboard.Repositories;

var builder = WebApplication.CreateBuilder(args);

// add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

// add identity db context & services
builder.Services.AddDbContext<RasDashboardContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddIdentity<Employee, IdentityRole>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false; 
    })
    .AddEntityFrameworkStores<RasDashboardContext>()
    .AddDefaultTokenProviders();

var authSection = builder.Configuration.GetSection("Authentication");

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine($"Connection string: {connectionString}");

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = authSection.GetValue<string>("LoginPath") ?? "/Identity/Account/Login";
    options.AccessDeniedPath = authSection.GetValue<string>("AccessDeniedPath") ?? "/Identity/Account/AccessDenied";
    options.LogoutPath = authSection.GetValue<string>("LogoutPath") ?? "/Identity/Account/Logout";
});

// add repositories
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

// own services
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IRoomsService,RoomsService>();
builder.Services.AddScoped<ITaskService,TaskService>();
builder.Services.AddSingleton<IHostedService, RoomImportHostedService>();

// add automapper
builder.Services.AddAutoMapper(typeof(Program));

//  add validators
builder.Services.AddValidatorsFromAssemblyContaining<TaskItemValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<EmployeeValidator>();

var app = builder.Build();

// configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// add auth services
app.UseAuthentication();
app.UseAuthorization();

// add custom middlewares
// app.UseMiddleware<UserTypeMiddleware>();

app.MapRazorPages();
app.MapControllers();

app.Run();