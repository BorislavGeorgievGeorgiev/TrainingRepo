using CookingRecipesSystem.Server.Domain.Entities;
using CookingRecipesSystem.Server.Domain.Exceptions;

namespace Domain.UnitTests
{
	public class RecipeTests
	{
		[Fact]
		public void TitleShouldThrowExceptionWhenNull()
		{
			// Arrange, Act & Assert
			Assert.Throws<InvalidRecipeException>(
				() => new Recipe(null!, "Test Content", "Test Id"));
		}
	}
}