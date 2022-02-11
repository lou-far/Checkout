using System;

namespace Checkout.Application.Interfaces.PaymentModule
{
    public interface IPaymentCreateService
    {
        Task<Dto.PaymentModule.Outbound.CreatePaymentAsyncDto> CreateAsync(
               Dto.PaymentModule.Inbound.CreatePaymentAsyncDto createPayment);
    }
}
