namespace CookingRecipesSystem.Server.Domain.Exceptions
{
  public class InvalidRecipeException : Exception
  {
    public InvalidRecipeException(string message)
        : base(message)
    {
    }
  }
}
