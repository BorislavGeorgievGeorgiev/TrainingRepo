using CookingRecipesSystem.Server.Application.Recipes.Commands.Create;
using CookingRecipesSystem.Server.Application.Recipes.Commands.Update;
using CookingRecipesSystem.Server.Web.Common;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace CookingRecipesSystem.Server.Web.Features
{
  public class RecipesController : ApiController
  {
    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateRecipeCommand command)
            => await this.Mediator.Send(command);

    [HttpPut]
    [Route(Id)]
    public async Task<ActionResult<Unit>> Update([FromBody] UpdateRecipeCommand command)
      => await this.Mediator.Send(command);
  }
}
