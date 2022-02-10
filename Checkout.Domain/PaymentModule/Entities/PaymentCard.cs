using System;

namespace Checkout.Domain.PaymentModule.Entities
{
    public class PaymentCard : DomainEntity
    {
        public PaymentCard(
            long permanentAccountNumber,
            string cardHolderName,
            byte expiresOnMonth,
            byte expiresOnYear,
            short cardVerificationValue)
        {
            PermanentAccountNumber = permanentAccountNumber;
            CardholderName = cardHolderName;
            ExpiresOnMonth = expiresOnMonth;
            ExpiresOnYear = expiresOnYear;
            CardVerificationValue = cardVerificationValue;
        }

        public PaymentCard()
        {
            CardholderName = string.Empty;
        }

        public int PaymentId { get; set; }

        public long PermanentAccountNumber { get; private set; }

        public string CardholderName { get; private set; }

        public byte ExpiresOnMonth { get; private set; }

        public byte ExpiresOnYear { get; private set; }

        public short CardVerificationValue { get; private set; }
    }
}
