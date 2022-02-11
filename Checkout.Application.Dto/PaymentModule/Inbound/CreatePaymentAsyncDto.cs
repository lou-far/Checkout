﻿using Checkout.Helper.Enums;

namespace Checkout.Application.Dto.PaymentModule.Inbound
{
    public class CreatePaymentAsyncDto
    {
        public CreatePaymentAsyncDto(
            int merchantId,
            int amount,
            Currency currency,
            CreatePaymentCardAsyncDto paymentCard)
        {
            MerchantId = merchantId;
            Amount = amount;
            Currency = currency;
            PaymentCard = paymentCard;
        }

        public int MerchantId { get; private set; }

        public int Amount { get; private set; }

        public Currency Currency { get; private set; }

        public CreatePaymentCardAsyncDto PaymentCard { get; private set; }
    }
}
