using CookingRecipesSystem.Server.Application.Common.Services;

namespace CookingRecipesSystem.Server.Application.Common.Interfaces
{
  public interface IDateTimeService : ITransientService
  {
    DateTime Now { get; }
  }
}
