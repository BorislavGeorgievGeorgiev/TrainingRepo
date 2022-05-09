using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CookingRecipesSystem.Server.Web.Common
{
  [Authorize]
  [ApiController]
  [Route("api/[controller]")]
  public abstract class ApiController : ControllerBase
  {
    protected const string Id = "{id}";

    private IMediator? _mediator;

    protected IMediator Mediator
        => this._mediator ??= this.HttpContext
            .RequestServices
            .GetService<IMediator>();
  }
}
