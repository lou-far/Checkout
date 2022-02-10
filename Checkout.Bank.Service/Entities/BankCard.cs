using System;

namespace Checkout.Bank.Service.Entities
{
    public class BankCard
    {
        public BankCard(
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

        public long PermanentAccountNumber { get; set; }

        public string CardholderName { get; set; }

        public byte ExpiresOnMonth { get; set; }

        public byte ExpiresOnYear { get; set; }

        public short CardVerificationValue { get; set; }
    }
}
