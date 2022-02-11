using System;
using Checkout.Domain;
using Checkout.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Checkout.DependencyResolution
{
    public static class PersistenceServices
    {
        public static IServiceCollection AddDbContexts(
            this IServiceCollection services)
        {
            services.AddDbContext<CheckoutDbContext>();

            return services;
        }

        public static IServiceCollection AddPersistenceServices(
            this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(SqlRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
