using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkout.Domain.AcquiringBankModule.Repositories;
using Checkout.Domain.PaymentModule.Entities;
using Checkout.Helper.Enums;

namespace Checkout.Domain.PaymentModule.Services
{
    public class PaymentStatusService
    {
        private readonly IAcquiringBankRepository _acquiringBankRepository;

        public PaymentStatusService(
            IAcquiringBankRepository acquiringBankRepository)
        {
            _acquiringBankRepository = acquiringBankRepository;
        }

        //public async Task<Payment> Update(
        //    int paymentId,
        //    PaymentStatus paymentStatus)
        //{

        //}
    }
}
