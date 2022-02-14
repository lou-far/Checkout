using System;

namespace Checkout.Application.Dto.PaymentModule.Outbound
{
    public class CreatePaymentAsyncDto
    {
        public CreatePaymentAsyncDto(
            int paymentId,
            bool isSuccessful,
            string message)
        {
            PaymentId = paymentId;
            IsSuccessful = isSuccessful;
            Message = message;
        }

        public int PaymentId { get; set; }

        public bool IsSuccessful { get; set; }

        public string Message { get; set; }
    }
}
