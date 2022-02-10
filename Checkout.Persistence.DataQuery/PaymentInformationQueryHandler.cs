using Checkout.Domain.PaymentModule.Interfaces;
using Checkout.Domain.PaymentModule.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Checkout.Persistence.DataQuery
{
    public class PaymentInformationQueryHandler : IPaymentInformationQueryHandler
    {
        private readonly CheckoutDbContext _checkoutDbContext;

        public PaymentInformationQueryHandler(
            CheckoutDbContext checkoutDbContext)
        {
            _checkoutDbContext = checkoutDbContext;
        }

        public async Task<PaymentInformation> GetAsync(
            int merchantId,
            int paymentId)
            => await _checkoutDbContext
                .Payments
                .Where(payment => payment.Id == paymentId)
                .Select(payment => new PaymentInformation(
                    payment.Amount,
                    payment.PaymentStatus,
                    payment.Currency,
                    new PaymentCardInformation(
                        payment.PaymentCard.PermanentAccountNumber.ToString(),
                        payment.PaymentCard.CardholderName,
                        payment.PaymentCard.ExpiresOnMonth,
                        payment.PaymentCard.ExpiresOnYear,
                        payment.PaymentCard.CardVerificationValue)
                    )
                )
            .AsNoTracking()
            .SingleOrDefaultAsync()
            ?? throw new KeyNotFoundException(
                $"MerchantId {merchantId}, PaymentId {paymentId}");
    }
}