using System;
using Checkout.Helper.Constants;
using Checkout.Services.Dto.AquiringBank;
using Checkout.Services.Interfaces;

namespace Checkout.Services.AcquiringBank
{
    public class MockAcquiringBankApi : IAcquiringBankApi
    {
        private int PermanentAccountNumberPrefixLength = 3;

        public bool MakePayment(
            PaymentDto payment)
        {
            string permanentAccountNumberPrefix = 
                new string(
                    payment
                    .PaymentCard
                    .PermanentAccountNumber
                    .ToString()
                    .Take(PermanentAccountNumberPrefixLength)
                    .ToArray()
                );

            switch (permanentAccountNumberPrefix)
            {
                case PermanentAccountNumberPrefixes.Ok:
                    return true;
                case PermanentAccountNumberPrefixes.Invalid:
                default:
                    return false;
            }
        }
    }
}
