﻿using AutoMapper;
using AutoMapper.QueryableExtensions;

using CookingRecipesSystem.Server.Application.Common.Interfaces;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace CookingRecipesSystem.Server.Application.Recipes.Queries.GetRecipes
{
  public class RecipesListQuery : IRequest<RecipeOutputModel[]>
  {
    public class RecipesListQueryHandler : IRequestHandler<
      RecipesListQuery, RecipeOutputModel[]>
    {
      private readonly IApplicationData _applicationData;
      private readonly IMapper _mapper;
      private readonly IUserManagerService _userManager;

      public RecipesListQueryHandler(IApplicationData applicationData,
        IMapper mapper, IUserManagerService userManager)
      {
        this._applicationData = applicationData;
        this._mapper = mapper;
        this._userManager = userManager;
      }

      public async Task<RecipeOutputModel[]> Handle(
        RecipesListQuery request, CancellationToken cancellationToken)
      {
        var recipesList = await this._applicationData
          .Recipes
          .ProjectTo<RecipeModel>(this._mapper.ConfigurationProvider)
          .OrderBy(x => x.Id)
          .ToListAsync(cancellationToken);

        var recipesListOutput = new List<RecipeOutputModel>();

        foreach (var recipe in recipesList)
        {
          var recipeOutput = this._mapper.Map<RecipeOutputModel>(recipe);
          recipeOutput.Author = await this._userManager.GetUserName(recipe.CreatedBy);
          recipesListOutput.Add(recipeOutput);
        }

        return recipesListOutput.ToArray();
      }
    }
  }
}
