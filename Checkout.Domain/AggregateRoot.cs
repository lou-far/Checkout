using System.ComponentModel.DataAnnotations.Schema;

namespace Checkout.Domain
{
    public abstract class AggregateRoot : DomainEntity
    {
        private readonly List<DomainEvent> _domainEvents = new List<DomainEvent>();

        protected AggregateRoot()
        {
        }

        [NotMapped]
        public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void ClearEvents() => _domainEvents.Clear();

        public void AppendEvent(DomainEvent domainEvent) => _domainEvents.Add(domainEvent);
    }
}
