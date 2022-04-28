using CookingRecipesSystem.Server.Application.Common.Services;

namespace CookingRecipesSystem.Server.Application.Common.Interfaces
{
  public interface IDateTime : ITransientService
  {
    DateTime Now { get; }
  }
}
