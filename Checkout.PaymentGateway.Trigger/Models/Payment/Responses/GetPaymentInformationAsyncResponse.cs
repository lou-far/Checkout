using Checkout.Helper.Enums;

namespace Checkout.PaymentGateway.Trigger.Models.Payment.Responses
{
    public class GetPaymentInformationAsyncResponse
    {
        public GetPaymentInformationAsyncResponse(
            int amount,
            PaymentStatus paymentStatus,
            Currency currency,
            GetPaymentCardInformationAsyncResponse paymentCard)
        {
            Amount = amount;
            PaymentStatus = paymentStatus;
            Currency = currency;
            PaymentCard = paymentCard;
        }

        public int Amount { get; private set; }

        public PaymentStatus PaymentStatus { get; private set; }

        public Currency Currency { get; private set; }

        public GetPaymentCardInformationAsyncResponse PaymentCard { get; private set; }
    }
}
