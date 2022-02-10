﻿using System;

namespace Checkout.Application.Dto.PaymentModule.Inbound
{
    public class CreatePaymentCardAsyncDto
    {
        public CreatePaymentCardAsyncDto(
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

        public long PermanentAccountNumber { get; private set; }

        public string CardholderName { get; private set; }

        public byte ExpiresOnMonth { get; private set; }

        public byte ExpiresOnYear { get; private set; }

        public short CardVerificationValue { get; private set; }
    }
}
