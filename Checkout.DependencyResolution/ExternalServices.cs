using System;
using Checkout.Services.AcquiringBank;
using Checkout.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Checkout.DependencyResolution
{
    public static class ExternalServices
    {
        public static IServiceCollection AddExternalServices(
            this IServiceCollection services)
        {
            services.AddScoped<IAcquiringBankApi, MockAcquiringBankApi>();

            return services;
        }
    }
}
