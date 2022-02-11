using System;

namespace Checkout.PaymentGateway.Trigger.Models.Payment.Responses
{
    public class GetPaymentCardInformationAsyncResponse
    {
        public GetPaymentCardInformationAsyncResponse(
           string maskedPermanentAccountNumber,
           string cardHolderName,
           string expiresOnMonth,
           string expiresOnYear,
           string cardVerificationValue)
        {
            MaskedPermanentAccountNumber = maskedPermanentAccountNumber;
            CardholderName = cardHolderName;
            ExpiresOnMonth = expiresOnMonth;
            ExpiresOnYear = expiresOnYear;
            CardVerificationValue = cardVerificationValue;
        }

        public string MaskedPermanentAccountNumber { get; private set; }

        public string CardholderName { get; private set; }

        public string ExpiresOnMonth { get; private set; }

        public string ExpiresOnYear { get; private set; }

        public string CardVerificationValue { get; private set; }
    }
}
