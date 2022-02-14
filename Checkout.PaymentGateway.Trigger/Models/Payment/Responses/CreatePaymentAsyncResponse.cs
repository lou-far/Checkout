using System;

namespace Checkout.Trigger.Models.Payment.Responses
{
    public class CreatePaymentAsyncResponse
    {
        public CreatePaymentAsyncResponse(
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
