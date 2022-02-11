using System;
using Checkout.Domain;

namespace Checkout.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CheckoutDbContext _checkoutDbContext;

        public UnitOfWork(
            CheckoutDbContext checkoutDbContext)
        {
            _checkoutDbContext = checkoutDbContext;
        }

        public async Task<int> CommitAsync()
        {
            return await _checkoutDbContext.SaveChangesAsync();
        }
    }
}
