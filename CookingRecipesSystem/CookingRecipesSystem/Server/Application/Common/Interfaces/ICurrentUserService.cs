using CookingRecipesSystem.Server.Application.Common.Services;

namespace CookingRecipesSystem.Server.Application.Common.Interfaces
{
  public interface ICurrentUserService : IScopedService
  {
    string GetUserId { get; }
  }
}
