using System.Reflection;

namespace Booking.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddImplementationsAsInterfaces(this IServiceCollection services
            , Type interfaceType
            , params Type[] implementationAssemblyTypes)
        {
            foreach (var assemblyType in implementationAssemblyTypes)
            {
                var implementationTypes = Assembly
                    .GetAssembly(assemblyType)
                    .GetTypes()
                    .Where(_ =>
                        _.IsClass
                        && !_.IsAbstract
                        && !_.IsInterface
                        && _.GetInterface(interfaceType.Name) != null
                        && !_.IsGenericType
                    );

                foreach (var implementationType in implementationTypes)
                {
                    var mainInterfaces = implementationType
                        .GetInterfaces()
                        .Where(_ => _.GenericTypeArguments.Count() == 0);

                    foreach (var mainInterface in mainInterfaces)
                    {
                        services.AddScoped(mainInterface, implementationType);
                    }
                }
            }
            return services;
        }
    }
}
