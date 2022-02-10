using System.Linq.Expressions;
using Checkout.Domain;
using Microsoft.EntityFrameworkCore;

namespace Checkout.Persistence
{
    public class SqlRepository<TAggregateRoot> : IRepository<TAggregateRoot> where TAggregateRoot : AggregateRoot
    {
        private readonly CheckoutDbContext _checkoutDbContext;

        protected SqlRepository(CheckoutDbContext checkoutDbContext)
        {
            _checkoutDbContext = checkoutDbContext;
        }

        public async Task<TAggregateRoot> GetAsync(
            Expression<Func<TAggregateRoot, bool>>? filter)
        {
            IQueryable<TAggregateRoot> query = GetQueryWithIncludes();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            TAggregateRoot aggregateRoot = await query.SingleOrDefaultAsync();
            if (aggregateRoot is null)
            {
                throw new InvalidOperationException($"Aggregate {typeof(TAggregateRoot).Name} not found.");
            }

            return aggregateRoot;
        }

        public async Task<IEnumerable<TAggregateRoot>> GetAllAsync(
            Expression<Func<TAggregateRoot, bool>>? filter)
        {
            IQueryable<TAggregateRoot> query = GetQueryWithIncludes();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            IEnumerable<TAggregateRoot> aggregateRoots = await query.ToListAsync();

            return aggregateRoots;
        }

        public async Task<IEnumerable<TAggregateRoot>> GetAllAsync()
            => await _checkoutDbContext.Set<TAggregateRoot>().ToListAsync();

        public async Task InsertAsync(
            TAggregateRoot aggregateRoot)
            => await _checkoutDbContext.Set<TAggregateRoot>().AddAsync(aggregateRoot);

        public void Update(
            TAggregateRoot aggregateRoot)
            => _checkoutDbContext.Set<TAggregateRoot>().Update(aggregateRoot);

        protected virtual IQueryable<TAggregateRoot> GetQueryWithIncludes()
            => _checkoutDbContext.Set<TAggregateRoot>().AsQueryable();
    }
}
