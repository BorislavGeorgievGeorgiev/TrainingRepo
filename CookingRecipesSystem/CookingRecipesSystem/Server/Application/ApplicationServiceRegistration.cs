using System.Reflection;

using CookingRecipesSystem.Server.Application.Common.Services;

using MediatR;

namespace CookingRecipesSystem.Server.Application
{
  public static class ApplicationServiceRegistration
  {
    public static IServiceCollection AddApplication(this IServiceCollection services)
        => services
            .AddAutoMapper(Assembly.GetExecutingAssembly())
            .AddMediatR(Assembly.GetExecutingAssembly());
    //.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>))
    //.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

    public static IServiceCollection AddConventionalServices(
        this IServiceCollection services,
        Assembly assembly)
    {
      var transientServiceInterfaceType = typeof(ITransientService);
      var singletonServiceInterfaceType = typeof(ISingletonService);
      var scopedServiceInterfaceType = typeof(IScopedService);

      var types = assembly
          .GetExportedTypes()
          .Where(t => t.IsClass && !t.IsAbstract)
          .Select(t => new
          {
            Service = t.GetInterface($"I{t.Name.Replace("Service", string.Empty)}"),
            Implementation = t
          })
          .Where(t => t.Service != null);

      foreach (var type in types)
      {
        if (transientServiceInterfaceType.IsAssignableFrom(type.Service))
        {
          services.AddTransient(type.Service, type.Implementation);
        }
        else if (singletonServiceInterfaceType.IsAssignableFrom(type.Service))
        {
          services.AddSingleton(type.Service, type.Implementation);
        }
        else if (scopedServiceInterfaceType.IsAssignableFrom(type.Service))
        {
          services.AddScoped(type.Service, type.Implementation);
        }
      }

      return services;
    }
  }
}
