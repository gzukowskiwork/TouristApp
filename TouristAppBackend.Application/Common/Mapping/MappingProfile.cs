using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace TouristAppBackend.Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplayMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplayMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes().Where(p =>
                p.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
