using FluentValidation;

namespace CookingRecipesSystem.Server.Application.Recipes.Commands.Update
{
  public class UpdateRecipeCommandValidator : AbstractValidator<UpdateRecipeCommand>
  {
    public UpdateRecipeCommandValidator()
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
