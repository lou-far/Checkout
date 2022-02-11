using System;

namespace Checkout.Services.Dto.AquiringBank
{
    public class PaymentCardDto
    {
        public PaymentCardDto(
            long permanentAccountNumber,
            string cardholderName,
            byte expiresOnMonth,
            byte expiresOnYear,
            short cardVerificationValue)
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

        public long PermanentAccountNumber { get; private set; }

        public string CardholderName { get; private set; }

        public byte ExpiresOnMonth { get; private set; }

        public byte ExpiresOnYear { get; private set; }

        public short CardVerificationValue { get; private set; }
    }
}
