using System;
using Checkout.Application.Interfaces.PaymentModule;
using Checkout.Application.PaymentModule;
using Checkout.Domain.PaymentModule.Repositories;
using Checkout.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Checkout.DependencyResolution
{
    public static class PaymentServices
    {
        public static IServiceCollection AddPaymentServices(
            this IServiceCollection services)
        {
            services.AddScoped<IPaymentRepository, PaymentRepository>();

            services.AddScoped<IPaymentCreateService, PaymentService>();
            services.AddScoped<IPaymentGetService, PaymentService>();

            return services;
        }
    }
}
