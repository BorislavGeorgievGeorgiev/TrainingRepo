using System.Reflection;

using CookingRecipesSystem.Server.Application.Common.Interfaces;
using CookingRecipesSystem.Server.Domain.Common;
using CookingRecipesSystem.Server.Domain.Entities;
using CookingRecipesSystem.Server.Infrastructure.Identity;

using Duende.IdentityServer.EntityFramework.Options;

using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CookingRecipesSystem.Server.Infrastructure.Persistence
{
  public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
  {
    private readonly ICurrentUser currentUserService;
    private readonly IDateTime dateTime;

    public ApplicationDbContext(
        DbContextOptions options,
        IOptions<OperationalStoreOptions> operationalStoreOptions,
        ICurrentUser currentUserService,
        IDateTime dateTime)
      : base(options, operationalStoreOptions)
    {
      this.currentUserService = currentUserService;
      this.dateTime = dateTime;
    }

    public DbSet<Recipe> Recipes { get; set; }

    public Task<int> SaveChanges(CancellationToken cancellationToken = new CancellationToken())
            => this.SaveChangesAsync(cancellationToken);

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
      foreach (var entry in this.ChangeTracker.Entries<IAuditableEntity>())
      {
        switch (entry.State)
        {
          case EntityState.Added:
            entry.Entity.CreatedBy ??= this.currentUserService.UserId;
            entry.Entity.CreatedOn = this.dateTime.Now;
            break;
          case EntityState.Modified:
            entry.Entity.ModifiedBy = this.currentUserService.UserId;
            entry.Entity.ModifiedOn = this.dateTime.Now;
            break;
        }
      }

      return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

      base.OnModelCreating(builder);
    }
  }
}
