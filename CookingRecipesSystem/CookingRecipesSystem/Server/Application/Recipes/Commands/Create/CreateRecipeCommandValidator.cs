using FluentValidation;

namespace CookingRecipesSystem.Server.Application.Recipes.Commands.Create
{
  public class CreateRecipeCommandValidator : AbstractValidator<CreateRecipeCommand>
  {
    public CreateRecipeCommandValidator()
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
