using System;

namespace Checkout.Services.Dto.AquiringBank
{
    public class PaymentCardDto
    {
        public PaymentCardDto(
            string permanentAccountNumber,
            string cardholderName,
            string expiresOnMonth,
            string expiresOnYear,
            string cardVerificationValue)
        {
            PermanentAccountNumber = permanentAccountNumber;
            CardholderName = cardholderName;
            ExpiresOnMonth = expiresOnMonth;
            ExpiresOnYear = expiresOnYear;
            CardVerificationValue = cardVerificationValue;
        }

        private PaymentCardDto()
        {
            CardholderName = string.Empty;
        }

        public string PermanentAccountNumber { get; private set; }

        public string CardholderName { get; private set; }

        public string ExpiresOnMonth { get; private set; }

        public string ExpiresOnYear { get; private set; }

        public string CardVerificationValue { get; private set; }
    }
}
