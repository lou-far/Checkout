using System;

namespace Checkout.Trigger.Models.Payment.Requests
{
    public class CreatePaymentCardAsyncRequest
    {
        public CreatePaymentCardAsyncRequest(
           string permanentAccountNumber,
           string cardHolderName,
           string expiresOnMonth,
           string expiresOnYear,
           string cardVerificationValue)
        {
            PermanentAccountNumber = permanentAccountNumber;
            CardholderName = cardHolderName;
            ExpiresOnMonth = expiresOnMonth;
            ExpiresOnYear = expiresOnYear;
            CardVerificationValue = cardVerificationValue;
        }

        public string PermanentAccountNumber { get; private set; }

        public string CardholderName { get; private set; }

        public string ExpiresOnMonth { get; private set; }

        public string ExpiresOnYear { get; private set; }

        public string CardVerificationValue { get; private set; }
    }
}
