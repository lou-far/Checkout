using System.Globalization;
using Checkout.DependencyResolution;
using Checkout.Trigger;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Checkout.Trigger
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
