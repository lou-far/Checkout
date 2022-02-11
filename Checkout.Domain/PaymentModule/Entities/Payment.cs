using Checkout.Helper.Enums;

namespace Checkout.Domain.PaymentModule.Entities
{
    public class Payment : AggregateRoot
    {
        public Payment(
            int merchantId,
            int amount,
            PaymentStatus paymentStatus,
            Currency currency,
            PaymentCard paymentCard)
        {
            MerchantId = merchantId;
            Amount = amount;
            PaymentStatus = paymentStatus;
            Currency = currency;
            PaymentCard = paymentCard;
        }

        private Payment()
        {
            PaymentCard = null;
        }

        public int MerchantId { get; private set; }

        public int Amount { get; private set; }

        public PaymentStatus PaymentStatus { get; private set; }

        public Currency Currency { get; private set; }

        public PaymentCard PaymentCard { get; private set; }
    }
}
