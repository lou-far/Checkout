using System.Text;
using System.Text.Json;
using Checkout.Helper.Configuration;
using Checkout.Services.Dto.AquiringBank;
using Checkout.Services.Interfaces;

namespace Checkout.Services.AcquiringBank
{
    public class AcquiringBankApi : IAcquiringBankApi
    {
        private readonly string _acquiringBankUrl;
        private readonly HttpClient _httpClient;

        public AcquiringBankApi(
            HttpClient httpClient)
        {
            _acquiringBankUrl = ConfigurationSettings.AcquiringBankApiUrl;
            _httpClient = httpClient;
        }

        public async Task<bool> CreatePaymentAsync(
            PaymentDto payment,
            CancellationToken cancellationToken = default)
        {
            Uri requestUri = new Uri($"{_acquiringBankUrl}/payments");

            string content = JsonSerializer.Serialize(payment);
            StringContent stringContent = new StringContent(
                content,
                Encoding.UTF8);

            HttpResponseMessage httpResponseMessage =
                await _httpClient.PostAsync(requestUri, stringContent, cancellationToken);

            return httpResponseMessage.IsSuccessStatusCode;
        }
    }
}
