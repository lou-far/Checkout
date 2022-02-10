using Checkout.Helper.Enums;

namespace Checkout.Domain.PaymentModule.Entities
{
    public class Payment : AggregateRoot
    {
        public Payment(
            int amount,
            Currency currency,
            PaymentCard paymentCard)
        {
            Amount = amount;
            Currency = currency;
            PaymentCard = paymentCard;
        }

        public int MerchantId { get; private set; }

        public int Amount { get; private set; }

        public PaymentStatus PaymentStatus { get; private set; }

        public Currency Currency { get; private set; }

        public PaymentCard PaymentCard { get; private set; }
    }
}
