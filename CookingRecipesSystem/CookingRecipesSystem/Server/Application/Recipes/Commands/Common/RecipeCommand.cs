using CookingRecipesSystem.Server.Domain.Entities;

namespace CookingRecipesSystem.Server.Application.Recipes.Commands.Common
{
  public abstract class RecipeCommand : IRecipe
  {
    public string Title { get; set; }
    public string Content { get; set; }
  }
}
