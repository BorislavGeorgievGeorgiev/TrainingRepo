using CookingRecipesSystem.Server.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace CookingRecipesSystem.Server.Application.Common.Interfaces
{
  public interface IApplicationData
  {
    DbSet<Recipe> Recipes { get; set; }

    Task<int> SaveChanges(CancellationToken cancellationToken);
  }
}
