using CookingRecipesSystem.Server.Domain.Entities;
using CookingRecipesSystem.Server.Infrastructure.Identity;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CookingRecipesSystem.Server.Infrastructure.Persistence.Initialize
{
  public static class DataSeeder
  {
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
      using (var context = serviceProvider.GetRequiredService<ApplicationDbContext>())
      {
        try
        {
          context.Database.Migrate();

          var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

          var defaultUser = new ApplicationUser
          {
            UserName = "admin@dev.com",
            Email = "admin@dev.com"
          };

          if (userManager.Users.All(u => u.Id != defaultUser.Id))
          {
            await userManager.CreateAsync(defaultUser, "Test1!");
          }

          if (context.Recipes.Any())
          {
            return;
          }

          var userId = await context.Users.Select(u => u.Id).FirstAsync();

          context.Recipes.Add(new Recipe("Test Recipe", "Test Recipe Content", userId)
          {
            CreatedOn = DateTime.Now.AddDays(-1),
          });

          await context.SaveChangesAsync();

        }
        catch (Exception ex)
        {
          var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

          logger.LogError(ex, "An error occurred while migrating or seeding the database.");
        }
      }
    }
  }
}
