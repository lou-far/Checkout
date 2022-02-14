using System;
using Checkout.Domain.AcquiringBankModule.Repositories;
using Checkout.Services.Dto.AquiringBank;
using Checkout.Services.Interfaces;

namespace Checkout.Services.AcquiringBank
{
    public class AcquiringBankRepository : IAcquiringBankRepository
    {
        private readonly IAcquiringBankApi _acquiringBankApi;

        public AcquiringBankRepository(
            IAcquiringBankApi acquiringBankApi)
        {
            _acquiringBankApi = acquiringBankApi;
        }

        public async Task<bool> CreatePaymentAsync(
            PaymentDto paymentDto)
        {
            bool isSuccessful = await _acquiringBankApi.CreatePaymentAsync(paymentDto);

            return isSuccessful;
        }
    }
}
