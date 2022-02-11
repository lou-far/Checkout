using System;
using Checkout.Domain.AcquiringBankModule.Repositories;
using Checkout.Services.AcquiringBank;
using Microsoft.Extensions.DependencyInjection;

namespace Checkout.DependencyResolution
{
    public static class AcquiringBankServices
    {
        public static IServiceCollection AddAcquiringBankServices(
            this IServiceCollection services)
        {
            services.AddScoped<IAcquiringBankRepository, AcquiringBankRepository>();

            return services;
        }
    }
}
