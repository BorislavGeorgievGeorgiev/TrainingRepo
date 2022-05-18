using CookingRecipesSystem.Server.Application.Common.Mappings;

namespace CookingRecipesSystem.Server.Application.Recipes.Queries.GetRecipes
{
  public class RecipeOutputModel : IMapFrom<RecipeModel>
  {
    public int Id { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public string Author { get; set; }
  }
}
