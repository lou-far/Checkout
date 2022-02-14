using System;

namespace Checkout.Trigger.Models.Bank.Requests
{
    public class CreateAcquiringBankRequest
    {
        public CreateAcquiringBankRequest(
            int amount,
            string currency,
            CreateAcquiringBankCardRequest paymentCard)
        {
            Amount = amount;
            Currency = currency;
            PaymentCard = paymentCard;
        }

        public CreateAcquiringBankRequest()
        {
            Currency = string.Empty;
        }

        public int Amount { get; private set; }

        public string Currency { get; private set; }

        public CreateAcquiringBankCardRequest PaymentCard { get; private set; }
    }
}
