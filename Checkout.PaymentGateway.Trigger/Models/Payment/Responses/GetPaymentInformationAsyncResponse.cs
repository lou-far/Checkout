using Checkout.Helper.Enums;

namespace Checkout.PaymentGateway.Trigger.Models.Payment.Responses
{
    public class GetPaymentInformationAsyncResponse
    {
        public GetPaymentInformationAsyncResponse(
            int amount,
            string paymentStatus,
            string currency,
            GetPaymentCardInformationAsyncResponse paymentCard)
        {
            Amount = amount;
            PaymentStatus = paymentStatus;
            Currency = currency;
            PaymentCard = paymentCard;
        }

        public int Amount { get; private set; }

        public string PaymentStatus { get; private set; }

        public string Currency { get; private set; }

        public GetPaymentCardInformationAsyncResponse PaymentCard { get; private set; }
    }
}
