using System;

namespace Checkout.Application.Dto.PaymentModule.Inbound
{
    public class CreatePaymentCardAsyncDto
    {
        public CreatePaymentCardAsyncDto(
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

        public string PermanentAccountNumber { get; set; }

        public string CardholderName { get; set; }

        public string ExpiresOnMonth { get; set; }

        public string ExpiresOnYear { get; set; }

        public string CardVerificationValue { get; set; }
    }
}
