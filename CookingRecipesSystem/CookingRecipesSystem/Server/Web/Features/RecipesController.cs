using CookingRecipesSystem.Server.Application.Recipes.Commands.Create;
using CookingRecipesSystem.Server.Application.Recipes.Commands.Update;
using CookingRecipesSystem.Server.Application.Recipes.Queries.GetRecipes;
using CookingRecipesSystem.Server.Web.Common;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CookingRecipesSystem.Server.Web.Features
{
  public class RecipesController : ApiController
  {
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<RecipesListOutputModel>> RecipesList(
           [FromRoute] RecipesListQuery query)
           => await this.Mediator.Send(query);

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateRecipeCommand command)
            => await this.Mediator.Send(command);

    [HttpPut]
    [Route(Id)]
    public async Task<ActionResult<Unit>> Update([FromBody] UpdateRecipeCommand command)
      => await this.Mediator.Send(command);
  }
}
