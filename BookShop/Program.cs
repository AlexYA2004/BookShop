using Microsoft.AspNetCore.Authentication.Cookies;
using BookShop;
using BookShop.DataBaseLogic;
using BookShop.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Logging.ClearProviders();

builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);

//builder.Host.UseNLog();

builder.Configuration.Bind("Project", new Config());

builder.Services.AddControllersWithViews();

builder.Services.InitializeRepositories();

builder.Services.InitializeServices();

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie((options => options.LoginPath = "/Account/Authorisation"));

builder.Services.AddAuthorization();


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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();


