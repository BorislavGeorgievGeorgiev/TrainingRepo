using CookingRecipesSystem.Server.Application.Common.Exceptions;
using CookingRecipesSystem.Server.Application.Common.Interfaces;
using CookingRecipesSystem.Server.Domain.Common;
using CookingRecipesSystem.Server.Domain.Entities;

using MediatR;

namespace CookingRecipesSystem.Server.Application.Recipes.Commands.Update
{
  public class UpdateRecipeCommand : IRequest, IEntity<int>, IRecipe
  {
    public int Id { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public class UpdateRecipeCommandHandler : IRequestHandler<UpdateRecipeCommand>
    {
      private readonly IApplicationData _applicationData;
      private readonly ICurrentUserService _currentUserService;

      public UpdateRecipeCommandHandler(
        IApplicationData applicationData,
        ICurrentUserService currentUserService)
      {
        this._applicationData = applicationData;
        this._currentUserService = currentUserService;
      }

      public async Task<Unit> Handle(UpdateRecipeCommand request, CancellationToken cancellationToken)
      {
        var recipe = await this._applicationData.Recipes.FindAsync(request.Id);

        if (recipe == null)
        {
          throw new NotFoundException(nameof(Recipe), request.Id);
        }

        recipe.Title = request.Title;
        recipe.Content = request.Content;

        await this._applicationData.SaveChangesAsynchron(cancellationToken);

        return Unit.Value;
      }
    }
  }
}
