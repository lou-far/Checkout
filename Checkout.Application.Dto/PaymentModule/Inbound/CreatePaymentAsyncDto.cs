using Checkout.Helper.Enums;

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

        public int MerchantId { get; set; }

        public int Amount { get; set; }

        public Currency Currency { get; set; }

        public CreatePaymentCardAsyncDto PaymentCard { get; set; }
    }
}
