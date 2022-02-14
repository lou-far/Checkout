using System;
using Checkout.Helper.Enums;

namespace Checkout.Trigger.Models.Payment.Requests
{
    public class CreatePaymentAsyncRequest
    {
        public CreatePaymentAsyncRequest(
            int merchantId,
            int amount,
            Currency currency,
            CreatePaymentCardAsyncRequest paymentCard)
        {
            MerchantId = merchantId;
            Amount = amount;
            Currency = currency;
            PaymentCard = paymentCard;
        }

        public int MerchantId { get; private set; }

        public int Amount { get; private set; }

        public Currency Currency { get; private set; }

        public CreatePaymentCardAsyncRequest PaymentCard { get; private set; }
    }
}
