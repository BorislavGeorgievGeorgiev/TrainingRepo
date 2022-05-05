using System.Security.Claims;

using CookingRecipesSystem.Server.Application.Common.Interfaces;

namespace CookingRecipesSystem.Server.Web.Services
{
  public class CurrentUserService : ICurrentUserService
  {
    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {

      this.GetUserId = httpContextAccessor
        .HttpContext?
        .User?
        .FindFirstValue(ClaimTypes.NameIdentifier);

      this.IsAuthenticated = this.GetUserId != null;
    }

    public string GetUserId { get; }

    public bool IsAuthenticated { get; }
  }
}
