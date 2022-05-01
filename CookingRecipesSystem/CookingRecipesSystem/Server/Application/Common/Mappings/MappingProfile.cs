using System.Reflection;

using AutoMapper;

namespace CookingRecipesSystem.Server.Application.Common.Mappings
{
  public class MappingProfile : Profile
  {
    private const string MappingMethodName = "Mapping";
    private readonly Type iMapFromType = typeof(IMapFrom<>);

    public MappingProfile()
            => this.ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());

    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
      var types = assembly.GetExportedTypes()
          .Where(t => t
              .GetInterfaces()
              .Any(i => i.IsGenericType
                  && i.GetGenericTypeDefinition() == this.iMapFromType))
          .ToList();

      foreach (var type in types)
      {
        var instance = Activator.CreateInstance(type);

        var methodInfo = type.GetMethod(MappingMethodName)
            ?? type.GetInterface(this.iMapFromType.Name)!.GetMethod(MappingMethodName);

        methodInfo?.Invoke(instance, new object[] { this });
      }
    }
  }
}
