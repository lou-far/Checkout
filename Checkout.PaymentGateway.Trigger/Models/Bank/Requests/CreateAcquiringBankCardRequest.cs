using System;

namespace Checkout.Trigger.Models.Bank.Requests
{
    public class CreateAcquiringBankCardRequest
    {
        public CreateAcquiringBankCardRequest(
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

        private CreateAcquiringBankCardRequest()
        {
            PermanentAccountNumber = string.Empty;
            CardholderName = string.Empty;
            ExpiresOnMonth = string.Empty;
            ExpiresOnYear = string.Empty;
            CardVerificationValue = string.Empty;
        }

        public string PermanentAccountNumber { get; private set; }

        public string CardholderName { get; private set; }

        public string ExpiresOnMonth { get; private set; }

        public string ExpiresOnYear { get; private set; }

        public string CardVerificationValue { get; private set; }
    }
}
