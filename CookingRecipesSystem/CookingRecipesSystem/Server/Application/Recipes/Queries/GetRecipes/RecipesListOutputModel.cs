namespace CookingRecipesSystem.Server.Application.Recipes.Queries.GetRecipes
{
  public class RecipesListOutputModel
  {
    public RecipesListOutputModel()
      => this.Recipes = new List<RecipeOutputModel>();

    public IList<RecipeOutputModel> Recipes { get; set; }
  }
}
