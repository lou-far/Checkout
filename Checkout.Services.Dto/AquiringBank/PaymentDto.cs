using System;

namespace Checkout.Services.Dto.AquiringBank
{
    public class PaymentDto
    {
        public PaymentDto(
            int amount,
            string currency,
            PaymentCardDto paymentCard)
        {
            Amount = amount;
            Currency = currency;
            PaymentCard = paymentCard;
        }

        private PaymentDto()
        {
            Currency = string.Empty;
        }

        public int Amount { get; private set; }

        public string Currency { get; private set; }

        public PaymentCardDto PaymentCard { get; private set; }
    }
}
