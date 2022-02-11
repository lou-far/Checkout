using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Checkout.Domain
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot : AggregateRoot
    {
        Task<TAggregateRoot> GetAsync(
            Expression<Func<TAggregateRoot, bool>>? filter = null);

        Task<IEnumerable<TAggregateRoot>> GetAllAsync();

        Task<IEnumerable<TAggregateRoot>> GetAllAsync(
            Expression<Func<TAggregateRoot, bool>>? filter = null);

        Task<EntityEntry<TAggregateRoot>> InsertAsync(
            TAggregateRoot aggregateRoot);

        void Update(
            TAggregateRoot aggregateRoot);
    }
}
