using CookingRecipesSystem.Server.Application.Common.Interfaces;
using CookingRecipesSystem.Server.Domain.Entities;

using MediatR;

namespace CookingRecipesSystem.Server.Application.Recipes.Commands.Create
{
  public class CreateRecipeCommand : IRecipe, IRequest<int>
  {
    public string Title { get; set; }
    public string Content { get; set; }

    public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, int>
    {
      private readonly IApplicationData applicationData;
      private readonly ICurrentUserService currentUserService;

      public CreateRecipeCommandHandler(
        IApplicationData applicationData,
        ICurrentUserService currentUserService)
      {
        this.applicationData = applicationData;
        this.currentUserService = currentUserService;
      }

      public async Task<int> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
      {
        var recipe = new Recipe(request.Title,
          request.Content,
          this.currentUserService.GetUserId);

        this.applicationData.Recipes.Add(recipe);

        await this.applicationData.SaveChanges(cancellationToken);

        return recipe.Id;
      }
    }
  }
}
