using CookingRecipesSystem.Server.Application.Common.Models;
using CookingRecipesSystem.Server.Application.Common.Services;

namespace CookingRecipesSystem.Server.Application.Common.Interfaces
{
  public interface IUserManagerService : ITransientService
  {
    Task<string> GetUserName(string userId);

    Task<(Result Result, string UserId)> CreateUser(string userName, string password);

    Task<Result> DeleteUser(string userId);
  }
}
