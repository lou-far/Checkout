using System;

namespace Checkout.PaymentGateway.Trigger.Models.Payment.Responses
{
    public class GetPaymentCardInformationAsyncResponse
    {
        public GetPaymentCardInformationAsyncResponse(
           string maskedPermanentAccountNumber,
           string cardHolderName,
           byte expiresOnMonth,
           byte expiresOnYear,
           short cardVerificationValue)
        {
            MaskedPermanentAccountNumber = maskedPermanentAccountNumber;
            CardholderName = cardHolderName;
            ExpiresOnMonth = expiresOnMonth;
            ExpiresOnYear = expiresOnYear;
            CardVerificationValue = cardVerificationValue;
        }

        public string MaskedPermanentAccountNumber { get; private set; }

        public string CardholderName { get; private set; }

        public byte ExpiresOnMonth { get; private set; }

        public byte ExpiresOnYear { get; private set; }

        public short CardVerificationValue { get; private set; }
    }
}
