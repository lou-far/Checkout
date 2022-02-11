using System;

namespace Checkout.Domain
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}
