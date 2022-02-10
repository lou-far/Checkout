using System;

namespace Checkout.Application.Dto.PaymentModule.Inbound
{
    public class GetPaymentInformationAsyncDto
    {
        public GetPaymentInformationAsyncDto(
            int merchantId,
            int paymentId)
        {
            MerchantId = merchantId;
            PaymentId = paymentId;
        }

        public int MerchantId { get; set; }

        public int PaymentId { get; set; }
    }
}
