
using CookingRecipesSystem.Server.Application.Recipes.Commands.Common;

using FluentValidation;

namespace CookingRecipesSystem.Server.Application.Recipes.Commands.Update
{
  public class UpdateRecipeCommandValidator : AbstractValidator<UpdateRecipeCommand>
  {
    public UpdateRecipeCommandValidator()
    {
      this.Include(new RecipeCommandValidator());

      this.RuleFor(r => r.Id)
        .NotEmpty();
    }
  }
}
