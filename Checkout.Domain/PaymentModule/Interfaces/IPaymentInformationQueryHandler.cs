using Checkout.Domain.PaymentModule.ValueObjects;

namespace Checkout.Domain.PaymentModule.Interfaces
{
    public interface IPaymentInformationQueryHandler
    {
        Task<PaymentInformation> GetAsync(
            int merchantId,
            int paymentId);
    }
}
