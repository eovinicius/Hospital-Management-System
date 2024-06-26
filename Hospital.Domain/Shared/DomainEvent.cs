namespace Hospital.Domain.Shared;

public interface DomainEvent<T> where T : AggregateRoot
{
    public DateTime OccurredOn { get; }
    public T EventData { get; }

}
