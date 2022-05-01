namespace CookingRecipesSystem.Server.Web
{
  public static class WebServiceRegistration
  {
    public static IServiceCollection AddWebComponents(this IServiceCollection services)
            => services
      .AddHttpContextAccessor();
    //.AddConventionalServices(typeof(WebServiceRegistration).Assembly);
  }
}
