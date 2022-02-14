using Checkout.Helper.Constants;

namespace Checkout.Helper.Configuration
{
    public static class ConfigurationSettings
    {
        public static string AcquiringBankApiUrl =>
            GetConfigurationValue<string>(ConfigurationKeys.AcquiringBankApiUrl);

        public static string DbConnectionString =>
            GetConfigurationValue<string>(ConfigurationKeys.DbConnectionString);

        private static T GetConfigurationValue<T>(string configurationKey)
        {
            string? configurationValue = Environment.GetEnvironmentVariable(configurationKey);

            return string.IsNullOrWhiteSpace(configurationValue)
                ? throw new InvalidOperationException($"{configurationKey} value is not provided in the configuration.")
                : Parse<T>(configurationValue);
        }

        private static T Parse<T>(string value)
        {
            if (typeof(T) == typeof(string))
            {
                return (T)(object)value;
            }

            if (typeof(T) == typeof(bool))
            {
                return (T)(object)bool.Parse(value);
            }

            throw new ArgumentOutOfRangeException($"Unable to parse '{typeof(T).FullName}' type.");
        }
    }
}
