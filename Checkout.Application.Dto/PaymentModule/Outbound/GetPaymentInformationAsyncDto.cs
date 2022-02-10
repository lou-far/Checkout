using Checkout.Helper.Enums;

namespace Checkout.Application.Dto.PaymentModule.Outbound
{
    public class GetPaymentInformationAsyncDto
    {
        public GetPaymentInformationAsyncDto(
            int amount,
            PaymentStatus paymentStatus,
            Currency currency,
            GetPaymentCardInformationAsyncDto paymentCard)
        {
            Amount = amount;
            PaymentStatus = paymentStatus;
            Currency = currency;
            PaymentCard = paymentCard;
        }

        public int Amount { get; private set; }

        public PaymentStatus PaymentStatus { get; private set; }

        public Currency Currency { get; private set; }

        public GetPaymentCardInformationAsyncDto PaymentCard { get; private set; }
    }
}
