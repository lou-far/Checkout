using System;

namespace Checkout.Trigger.Models.Payment.Responses
{
    public class CreatePaymentAsyncResponse
    {
        public CreatePaymentAsyncResponse(
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
