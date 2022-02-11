using System;

namespace Checkout.Application.Dto.PaymentModule.Outbound
{
    public class CreatePaymentAsyncDto
    {
        public CreatePaymentAsyncDto(
            int paymentId,
            bool isSuccessful)
        {
            PaymentId = paymentId;
            IsSuccessful = isSuccessful;
        }

        public int PaymentId { get; set; }

        public bool IsSuccessful { get; set; }
    }
}
