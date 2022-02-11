using Checkout.Services.Dto.AquiringBank;

namespace Checkout.Services.Interfaces
{
    public interface IAcquiringBankApi
    {
        bool MakePayment(
            PaymentDto payment);
    }
}