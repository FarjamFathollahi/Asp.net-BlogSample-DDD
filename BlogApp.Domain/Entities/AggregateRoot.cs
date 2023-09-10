namespace BlogApp.Domain.Entities
{
    public abstract class AggregateRoot<TId> : Entity<TId>
    {
        public string ExternalId { get; protected set; } = Guid.NewGuid().ToString();
    }
}
