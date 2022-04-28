using CookingRecipesSystem.Server.Domain.Common;
using CookingRecipesSystem.Server.Domain.Exceptions;

namespace CookingRecipesSystem.Server.Domain.Entities
{
  public class Recipe : AuditableEntity<Guid>
  {
    private const string InvalidRecipeExceptionMessageTitle = "Recipe title cannot be";
    private const int RecipeTitleMaxLength = 100;

    private string? title;

    public string Title
    {
      get
      {
        return this.title!;
      }
      set
      {
        if (string.IsNullOrEmpty(value))
        {
          throw new InvalidRecipeException(
            $"{InvalidRecipeExceptionMessageTitle} null.");
        }

        if (value.Length > RecipeTitleMaxLength)
        {
          throw new InvalidRecipeException(
            $"{InvalidRecipeExceptionMessageTitle} more than {RecipeTitleMaxLength} symbols.");
        }

        this.title = value;
      }
    }

    public string Content { get; set; }
  }
}
