using System.Globalization;
using Checkout.DependencyResolution;
using Checkout.PaymentGateway.Trigger;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Checkout.PaymentGateway.Trigger
{
    public class Startup : FunctionsStartup
    {
        private const string DefaultCulture = "en";

        public override void Configure(
            IFunctionsHostBuilder builder)
        {
            builder.Services.AddTriggerCompositionRoot();

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(DefaultCulture);
        }
    }
}
