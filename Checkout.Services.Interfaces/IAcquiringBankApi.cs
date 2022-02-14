using Checkout.Services.Dto.AquiringBank;

namespace Checkout.Services.Interfaces
{
    public interface IAcquiringBankApi
    {
        Task<bool> CreatePaymentAsync(
            PaymentDto payment,
            CancellationToken cancellationToken = default);
    }
}