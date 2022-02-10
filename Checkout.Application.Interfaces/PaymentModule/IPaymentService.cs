using System;

using Inbound = Checkout.Application.Dto.PaymentModule.Inbound;
using Outbound = Checkout.Application.Dto.PaymentModule.Outbound;

namespace Checkout.Application.Interfaces.PaymentModule
{
    public interface IPaymentService
    {
        Task<Outbound.GetPaymentInformationAsyncDto> GetAsync(
            Inbound.GetPaymentInformationAsyncDto inboundPaymentInformation);
    }
}
