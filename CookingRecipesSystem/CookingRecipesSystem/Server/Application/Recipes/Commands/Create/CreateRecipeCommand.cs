using CookingRecipesSystem.Server.Application.Common.Interfaces;
using CookingRecipesSystem.Server.Domain.Entities;

using MediatR;

namespace CookingRecipesSystem.Server.Application.Recipes.Commands.Create
{
  public class CreateRecipeCommand : IRequest<int>, IRecipe
  {
    public string Title { get; set; }

    public string Content { get; set; }


    public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, int>
    {
      private readonly IApplicationData _applicationData;
      private readonly ICurrentUserService _currentUserService;

      public CreateRecipeCommandHandler(
        IApplicationData applicationData,
        ICurrentUserService currentUserService)
      {
        this._applicationData = applicationData;
        this._currentUserService = currentUserService;
      }

      public async Task<int> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
      {
        var recipe = new Recipe(request.Title,
          request.Content,
          this._currentUserService.GetUserId);

        this._applicationData.Recipes.Add(recipe);

        await this._applicationData.SaveChanges(cancellationToken);

        return recipe.Id;
      }
    }
  }
}
