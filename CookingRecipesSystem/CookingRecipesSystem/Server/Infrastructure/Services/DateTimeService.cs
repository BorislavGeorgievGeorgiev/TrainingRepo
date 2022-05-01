using CookingRecipesSystem.Server.Application.Common.Interfaces;

namespace CookingRecipesSystem.Server.Infrastructure.Services
{
  public class DateTimeService : IDateTimeService
  {
    public DateTime Now => DateTime.Now;
  }
}
