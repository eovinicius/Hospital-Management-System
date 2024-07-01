namespace Hospital.Domain.Shared;

public interface IRepositoryGeneric<TAggregateRoot> : IRepository where TAggregateRoot : AggregateRoot
{
    Task Add(TAggregateRoot aggregate);
    Task<TAggregateRoot> FindById(Guid id);
}
