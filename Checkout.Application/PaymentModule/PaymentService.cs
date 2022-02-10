using Checkout.Application.Interfaces.PaymentModule;
using Checkout.Domain.PaymentModule.Interfaces;
using Checkout.Domain.PaymentModule.ValueObjects;

using Inbound = Checkout.Application.Dto.PaymentModule.Inbound;
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
            Inbound.GetPaymentInformationAsyncDto inboundPaymentInformation)
        {
            PaymentInformation paymentInformation =
                await _paymentInformationQueryHandler.GetAsync(
                    inboundPaymentInformation.MerchantId,
                    inboundPaymentInformation.PaymentId);

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
