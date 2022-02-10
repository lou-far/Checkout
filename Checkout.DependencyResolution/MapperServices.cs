using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Checkout.DependencyResolution
{
    public static class MapperServices
    {
        public static IServiceCollection AddMapperServices(
            this IServiceCollection services)
        {
            IEnumerable<Assembly> assemblies = AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(x => !string.IsNullOrEmpty(x.FullName) && x.FullName.StartsWith("Checkout", StringComparison.Ordinal));

            services.AddAutoMapper(assemblies);

            return services;
        }
    }
}
