using CookingRecipesSystem.Server.Application.Common.Interfaces;
using CookingRecipesSystem.Server.Infrastructure.Identity;
using CookingRecipesSystem.Server.Infrastructure.Persistence;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CookingRecipesSystem.Server.Infrastructure
{
  public static class InfrastructureServiceRegistration
  {
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
      services
          .AddDbContext<ApplicationDbContext>(options => options
              .UseSqlServer(
                  configuration.GetConnectionString("DefaultConnection"),
                  b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)))
          .AddScoped<IApplicationData>(provider => provider.GetService<ApplicationDbContext>());

      services
          .AddDefaultIdentity<ApplicationUser>()
          .AddEntityFrameworkStores<ApplicationDbContext>();

      services
          .AddIdentityServer()
          .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

      services
        .AddHealthChecks()
        .AddDbContextCheck<ApplicationDbContext>();

      //services
      //    .AddConventionalServices(typeof(InfrastructureServiceRegistration).Assembly);

      services.Configure<IdentityOptions>(options =>
      {
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireDigit = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredUniqueChars = 0;
        options.Password.RequiredLength = 3;
      });

      services
          .AddAuthentication()
          .AddIdentityServerJwt();

      return services;
    }
  }
}
