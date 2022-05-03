using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace CookingRecipesSystem.Server.Web.Common
{
  [ApiController]
  [Route("api/[controller]")]
  public abstract class ApiController : ControllerBase
  {
    private IMediator? mediator;

    protected IMediator Mediator
        => this.mediator ??= this.HttpContext
            .RequestServices
            .GetService<IMediator>();
  }
}
