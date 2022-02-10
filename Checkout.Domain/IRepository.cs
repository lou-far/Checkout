using System.Linq.Expressions;

namespace Checkout.Domain
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot : AggregateRoot
    {
        Task<TAggregateRoot> GetAsync(
            Expression<Func<TAggregateRoot, bool>>? filter = null);

        Task<IEnumerable<TAggregateRoot>> GetAllAsync();

        Task<IEnumerable<TAggregateRoot>> GetAllAsync(
            Expression<Func<TAggregateRoot, bool>>? filter = null);

        Task InsertAsync(
            TAggregateRoot aggregateRoot);

        void Update(
            TAggregateRoot aggregateRoot);
    }
}
