namespace CookingRecipesSystem.Server.Domain.Entities
{
  public interface IRecipe
  {
    public string Title { get; set; }

    public string Content { get; set; }
  }
}
