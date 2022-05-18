using CookingRecipesSystem.Server.Domain.Common;
using CookingRecipesSystem.Server.Domain.Exceptions;

namespace CookingRecipesSystem.Server.Domain.Entities
{
  public class Recipe : AuditableEntity<int>, IRecipe
  {
    private const string _RecipeTitleCannot = "Recipe title cannot be";
    private const string _RecipeContentCannot = "Recipe content cannot be";
    private const int _RecipeTitleMaxLength = 100;

    private string? _title;
    private string? _content;

    public Recipe(string title, string content, string createdBy)
    {
      this.Title = title;
      this.Content = content;
      this.CreatedBy = createdBy;
    }

    public string Title
    {
      get
      {
        return this._title!;
      }
      set
      {
        if (string.IsNullOrEmpty(value))
        {
          throw new InvalidRecipeException(
            $"{_RecipeTitleCannot} null.");
        }

        if (value.Length > _RecipeTitleMaxLength)
        {
          throw new InvalidRecipeException(
            $"{_RecipeTitleCannot} more than {_RecipeTitleMaxLength} symbols.");
        }

        this._title = value;
      }
    }

    public string Content
    {
      get
      {
        return this._content!;
      }
      set
      {
        if (string.IsNullOrEmpty(value))
        {
          throw new InvalidRecipeException(
            $"{_RecipeContentCannot} null.");
        }

        this._content = value;
      }
    }

  }
}
