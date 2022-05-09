
using CookingRecipesSystem.Server.Application.Recipes.Commands.Common;

using FluentValidation;

namespace CookingRecipesSystem.Server.Application.Recipes.Commands.Create
{
  public class CreateRecipeCommandValidator : AbstractValidator<CreateRecipeCommand>
  {
    public CreateRecipeCommandValidator()
    {
      this.Include(new RecipeCommandValidator());
    }
  }
}
