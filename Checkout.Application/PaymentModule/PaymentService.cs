using Checkout.Application.Interfaces.PaymentModule;
using Checkout.Domain.PaymentModule.Interfaces;
using Checkout.Domain.PaymentModule.ValueObjects;

using Outbound = Checkout.Application.Dto.PaymentModule.Outbound;

namespace Checkout.Application.PaymentModule
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentInformationQueryHandler _paymentInformationQueryHandler;

        public PaymentService(
            IPaymentInformationQueryHandler paymentInformationQueryHandler)
        {
            _paymentInformationQueryHandler = paymentInformationQueryHandler;
        }

        public async Task<Outbound.GetPaymentInformationAsyncDto> GetAsync(
            int identifier)
        {
            PaymentInformation paymentInformation =
                await _paymentInformationQueryHandler.GetAsync(identifier);

            Outbound.GetPaymentInformationAsyncDto outboundPaymentInformation = new Outbound.GetPaymentInformationAsyncDto(
                paymentInformation.Amount,
                paymentInformation.PaymentStatus,
                paymentInformation.Currency,
                new Outbound.GetPaymentCardInformationAsyncDto(
                    paymentInformation.PaymentCard.MaskedPermanentAccountNumber,
                    paymentInformation.PaymentCard.CardholderName,
                    paymentInformation.PaymentCard.ExpiresOnMonth,
                    paymentInformation.PaymentCard.ExpiresOnYear,
                    paymentInformation.PaymentCard.CardVerificationValue)
                );

            return outboundPaymentInformation;
        }
    }
}
