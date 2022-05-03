
using CookingRecipesSystem.Server.Application.Common.Interfaces;
using CookingRecipesSystem.Server.Application.Common.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CookingRecipesSystem.Server.Infrastructure.Identity
{
  public class UserManagerService : IUserManagerService
  {
    private readonly UserManager<ApplicationUser> userManager;

    public UserManagerService(UserManager<ApplicationUser> userManager)
        => this.userManager = userManager;

    public async Task<string> GetUserName(string userId)
        => await this.userManager
            .Users
            .Where(u => u.Id == userId)
            .Select(u => u.UserName)
            .FirstOrDefaultAsync();

    public async Task<(Result Result, string UserId)> CreateUser(string userName, string password)
    {
      var ApplicationUser = new ApplicationUser
      {
        UserName = userName,
        Email = userName,
      };

      var result = await this.userManager.CreateAsync(ApplicationUser, password);

      return (result.ToApplicationResult(), ApplicationUser.Id);
    }

    public async Task<Result> DeleteUser(string userId)
    {
      var ApplicationUser = this.userManager
          .Users
          .SingleOrDefault(u => u.Id == userId);

      if (ApplicationUser != null)
      {
        return await this.DeleteUser(ApplicationUser);
      }

      return Result.Success;
    }

    public async Task<Result> DeleteUser(ApplicationUser ApplicationUser)
    {
      var result = await this.userManager.DeleteAsync(ApplicationUser);

      return result.ToApplicationResult();
    }
  }
}
