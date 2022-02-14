using System;
using Checkout.Services.Dto.AquiringBank;

namespace Checkout.Domain.AcquiringBankModule.Repositories
{
    public interface IAcquiringBankRepository
    {
        Task<bool> CreatePaymentAsync(
               PaymentDto paymentDto);
    }
}
