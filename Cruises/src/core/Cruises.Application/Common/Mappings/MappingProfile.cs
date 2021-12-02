using System;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace Cruises.Application.Common.Mappings
{
  public class MappingProfile
    : Profile
  {
    public MappingProfile()
    {
      ApplyMappingsFromAssembly(
        Assembly.GetExecutingAssembly()
      );
    }

    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
      var types = assembly.GetExportedTypes().Where(
        typeT => typeT.GetInterfaces().Any(
          typeI => typeI.IsGenericType && typeI
            .GetGenericTypeDefinition() == typeof(IMapFrom<>)
        )
      ).ToList();

      foreach (var typeT in types)
      {
        var instance = Activator.CreateInstance(typeT);

        var methodInfo = typeT.GetMethod("Mapping") ?? typeT
          .GetInterface("IMapFrom`1").GetMethod("Mapping");

        methodInfo?.Invoke(
          instance,
          new object[] { this }
        );
      }
    }
  }
}
