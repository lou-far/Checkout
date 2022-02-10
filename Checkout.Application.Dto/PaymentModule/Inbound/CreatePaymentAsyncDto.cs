using Checkout.Helper.Enums;

namespace Checkout.Application.Dto.PaymentModule.Inbound
{
    public class CreatePaymentAsyncDto
    {
        public CreatePaymentAsyncDto(
            int amount,
            Currency currency,
            CreatePaymentCardAsyncDto paymentCard)
        {
            Amount = amount;
            Currency = currency;
            PaymentCard = paymentCard;
        }

        public int Amount { get; private set; }

        public PaymentStatus PaymentStatus { get; private set; }

        public Currency Currency { get; private set; }

        public CreatePaymentCardAsyncDto PaymentCard { get; private set; }
    }
}
