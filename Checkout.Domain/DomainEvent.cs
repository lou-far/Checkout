using Newtonsoft.Json;

namespace Checkout.Domain
{
    public abstract class DomainEvent
    {
        private string? _operationId;

        [JsonProperty]
        public string OperationId
        {
            get => _operationId ??= Guid.NewGuid().ToString();
            private set => _operationId = value;
        }
    }
}
