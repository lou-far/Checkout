using Checkout.Domain.PaymentModule.Entities;
using Checkout.Domain.PaymentModule.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Checkout.Persistence
{
    public class PaymentRepository : SqlRepository<Payment>, IPaymentRepository
    {
        private readonly CheckoutDbContext _checkoutDbContext;

        public PaymentRepository(
            CheckoutDbContext checkoutDbContext)
            : base(
                checkoutDbContext)
        {
            _checkoutDbContext = checkoutDbContext;
        }

        protected override IQueryable<Payment> GetQueryWithIncludes()
            => _checkoutDbContext.Set<Payment>()
                .Include(x => x.PaymentCard);
    }
}