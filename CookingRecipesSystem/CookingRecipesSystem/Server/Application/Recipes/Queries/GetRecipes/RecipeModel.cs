using CookingRecipesSystem.Server.Application.Common.Mappings;
using CookingRecipesSystem.Server.Domain.Entities;

namespace CookingRecipesSystem.Server.Application.Recipes.Queries.GetRecipes
{
  public class RecipeModel : IMapFrom<Recipe>
  {
    public int Id { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public string CreatedBy { get; set; }
  }
}
