using Blazored.SessionStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MudBlazor;
using MudBlazor.Services;
using MudBlazorServerId.Areas.Identity;
using MudBlazorServerId.Data;
using MudBlazorServerId.Helpers;
using MudBlazorServerId.IdentityUtils;
using System;

var builder = WebApplication.CreateBuilder(args);
// TODO need a url for this
//builder.WebHost.UseUrls("http://identity.verticalapps.co.uk:80", "https://identity.verticalapps.co.uk:443");
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 5;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedAccount = false;
}).AddEntityFrameworkStores<ApplicationDbContext>()
 .AddDefaultTokenProviders();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddSingleton<MudBlazorTheme>();

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;
    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 5000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});

builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

var app = builder.Build();

// create default accounts
using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();
   // context.Database.Migrate();

    var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var user1 = userManager.FindByEmailAsync("User@test.com").Result;
    if (user1 == null)
    {
        user1 = new IdentityUser()
        {
            Email = "User@test.com",
            UserName = "User@test.com",
            EmailConfirmed = true
        };
        userManager.CreateAsync(user1, "Test.1234").Wait();
    }

    var user2 = userManager.FindByEmailAsync("Admin@test.com").Result;
    if (user2 == null)
    {
        user2 = new IdentityUser()
        {
            Email = "Admin@test.com",
            UserName = "Admin@test.com",
            EmailConfirmed = true
        };
        userManager.CreateAsync(user2, "Test.1234").Wait();
    }

    var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var role1 = roleManager.FindByNameAsync("UserRole").Result;
    if (role1 == null)
    {
        role1 = new IdentityRole()
        {
            Name = "UserRole"
        };
        roleManager.CreateAsync(role1).Wait();
    }

    var role2 = roleManager.FindByNameAsync("AdminRole").Result;
    if (role2 == null)
    {
        role2 = new IdentityRole()
        {
            Name = "AdminRole"
        };
        roleManager.CreateAsync(role2).Wait();
    }

    IdentityResult roleresult1 = await userManager.AddToRoleAsync(user1, "UserRole");
    IdentityResult roleresult2 = await userManager.AddToRoleAsync(user2, "AdminRole");
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<BlazorCookieLoginMiddleware<IdentityUser>>();
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();