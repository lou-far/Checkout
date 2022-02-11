using System;

namespace Checkout.Domain.PaymentModule.Entities
{
    public class PaymentCard : DomainEntity
    {
        public PaymentCard(
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

        private PaymentCard()
        {
            CardholderName = string.Empty;
        }

        public int PaymentId { get; set; }

        public string PermanentAccountNumber { get; private set; }

        public string CardholderName { get; private set; }

        public string ExpiresOnMonth { get; private set; }

        public string ExpiresOnYear { get; private set; }

        public string CardVerificationValue { get; private set; }
    }
}
