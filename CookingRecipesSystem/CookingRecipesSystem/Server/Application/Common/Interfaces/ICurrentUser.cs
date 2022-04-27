using CookingRecipesSystem.Server.Application.Common.Services;

namespace CookingRecipesSystem.Server.Application.Common.Interfaces
{
  public interface ICurrentUser : IScopedService
  {
    string UserId { get; }
  }
}
