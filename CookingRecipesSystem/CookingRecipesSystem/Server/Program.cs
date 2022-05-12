using System.Reflection;

using CookingRecipesSystem.Server.Application;
using CookingRecipesSystem.Server.Infrastructure;
using CookingRecipesSystem.Server.Infrastructure.Persistence.Initialize;
using CookingRecipesSystem.Server.Web;

using Microsoft.AspNetCore.Mvc.Razor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddConventionalServices(Assembly.GetExecutingAssembly());

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddWebComponents();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.Configure<RazorViewEngineOptions>(o =>
{
  o.AreaPageViewLocationFormats.Add("/Web/Areas/Identity/Pages/Shared/{0}" + RazorViewEngine.ViewExtension);
  o.AreaPageViewLocationFormats.Add("/Web/Pages/{0}" + RazorViewEngine.ViewExtension);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseMigrationsEndPoint();
  app.UseWebAssemblyDebugging();
}
else
{
  app.UseExceptionHandler("/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;

  await DataSeeder.SeedAsync(services);
}

app.UseHealthChecks("/health");

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
