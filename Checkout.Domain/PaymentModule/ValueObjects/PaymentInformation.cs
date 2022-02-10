using Checkout.Helper.Enums;

namespace Checkout.Domain.PaymentModule.ValueObjects
{
    public class PaymentInformation
    {
        public PaymentInformation(
            int amount,
            PaymentStatus paymentStatus,
            Currency currency,
            PaymentCardInformation paymentCard)
        {
            Amount = amount;
            PaymentStatus = paymentStatus;
            Currency = currency;
            PaymentCard = paymentCard;
        }

        public int Amount { get; private set; }

        public PaymentStatus PaymentStatus { get; private set; }

        public Currency Currency { get; private set; }

        public PaymentCardInformation PaymentCard { get; private set; }
    }
}
