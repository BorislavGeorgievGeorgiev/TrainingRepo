namespace CookingRecipesSystem.Server.Infrastructure.Persistence.Initialize
{
  public interface IDataSeeder
  {
    public Task SeedDataAsync(IServiceProvider serviceProvider);
  }
}
