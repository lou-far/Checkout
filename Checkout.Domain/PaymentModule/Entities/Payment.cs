using Checkout.Helper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Domain.PaymentModule.Entities
{
    public class Payment : DomainEntity
    {
        public Payment(
            int amount,
            Currency currency,
            PaymentCard paymentCard)
        {
            Amount = amount;
            Currency = currency;
            PaymentCard = paymentCard;
        }

        public int Amount { get; private set; }

        public Currency Currency { get; private set; }

        public PaymentCard PaymentCard { get; private set; }
    }
}
