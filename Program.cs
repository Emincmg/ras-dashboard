using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RhsDashboard.Areas.Identity.Data;
using RhsDashboard.Interfaces;
using RhsDashboard.Models;
using RhsDashboard.Services;
using RhsDashboard.FluentValidators;
using RhsDashboard.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

// Add identity db context & services
builder.Services.AddDbContext<RhsDashboardContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<Employee, IdentityRole>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false; 
    })
    .AddEntityFrameworkStores<RhsDashboardContext>()
    .AddDefaultTokenProviders();

var authSection = builder.Configuration.GetSection("Authentication");

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = authSection.GetValue<string>("LoginPath") ?? "/Identity/Account/Login";
    options.AccessDeniedPath = authSection.GetValue<string>("AccessDeniedPath") ?? "/Identity/Account/AccessDenied";
    options.LogoutPath = authSection.GetValue<string>("LogoutPath") ?? "/Identity/Account/Logout";
});

// Add repositories
builder.Services.AddScoped<IRoomRepository, RoomRepository>();

// Own services
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IRoomsService,RoomsService>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddSingleton<IHostedService, RoomImportHostedService>();

//add validators
builder.Services.AddValidatorsFromAssemblyContaining<TaskItemValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<EmployeeValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Add auth services
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();