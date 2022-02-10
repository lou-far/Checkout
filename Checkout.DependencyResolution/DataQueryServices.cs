using System;
using Checkout.Domain.PaymentModule.Interfaces;
using Checkout.Persistence.DataQuery;
using Microsoft.Extensions.DependencyInjection;

namespace Checkout.DependencyResolution
{
    public static class DataQueryServices
    {
        public static IServiceCollection AddDataQueryServices(
            this IServiceCollection services)
        {
            services.AddScoped<IPaymentInformationQueryHandler, PaymentInformationQueryHandler>();

            return services;
        }
    }
}
