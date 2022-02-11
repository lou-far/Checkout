using System;
using Checkout.Application.Dto.PaymentModule.Inbound;
using Checkout.Application.Dto.PaymentModule.Inbound.Validators;
using Checkout.Application.Interfaces.PaymentModule;
using Checkout.Application.PaymentModule;
using Checkout.Domain.PaymentModule.Repositories;
using Checkout.Persistence;
using FluentValidation;
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

            services.AddScoped<IValidator<CreatePaymentAsyncDto>, CreatePaymentAsyncDtoValidator>();
            services.AddScoped<IValidator<CreatePaymentCardAsyncDto>, CreatePaymentCardAsyncDtoValidator>();

            return services;
        }
    }
}
