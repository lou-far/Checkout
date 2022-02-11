using System;
using Microsoft.Extensions.DependencyInjection;

namespace Checkout.DependencyResolution
{
    public static class ServiceCollectionDescriptor
    {
        public static IServiceCollection AddTriggerCompositionRoot(
            this IServiceCollection services)
            => services
                .AddAcquiringBankServices()
                .AddDataQueryServices()
                .AddDbContexts()
                .AddExternalServices()
                .AddMapperServices()
                .AddPaymentServices()
                .AddPersistenceServices();
    }
}
