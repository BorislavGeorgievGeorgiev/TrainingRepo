using FluentValidation;

namespace CookingRecipesSystem.Server.Application.Recipes.Commands.Common
{
  public class RecipeCommandValidator : AbstractValidator<RecipeCommand>
  {
    public RecipeCommandValidator()
    {
      this.RuleFor(r => r.Title)
        .NotEmpty()
        .MinimumLength(RecipesConstants.TitleMinLength)
        .MaximumLength(RecipesConstants.TitleMaxLength);

      this.RuleFor(r => r.Content)
        .NotEmpty()
        .MinimumLength(RecipesConstants.ContentMinLength);
    }
  }
}
