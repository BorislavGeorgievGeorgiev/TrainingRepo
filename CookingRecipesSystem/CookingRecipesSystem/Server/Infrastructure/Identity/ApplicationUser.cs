using CookingRecipesSystem.Server.Domain.Entities;

using Microsoft.AspNetCore.Identity;

namespace CookingRecipesSystem.Server.Infrastructure.Identity
{
  public class ApplicationUser : IdentityUser
  {
    public ICollection<Recipe> Recipes { get; } = new List<Recipe>();
  }
}
