using CookingRecipesSystem.Server.Domain.Entities;
using CookingRecipesSystem.Server.Infrastructure.Identity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CookingRecipesSystem.Server.Infrastructure.Persistence.Configurations
{
  public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
  {
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
      builder
        .HasKey(r => r.Id);

      builder
        .Property(r => r.Title)
        .IsRequired();

      builder
        .Property(r => r.Content)
        .IsRequired();

      builder
        .Property(r => r.CreatedBy)
        .IsRequired();

      builder
        .HasOne(typeof(ApplicationUser))
        .WithMany("Recipes")
        .HasForeignKey("CreatedBy")
        .OnDelete(DeleteBehavior.Restrict);
    }
  }
}
