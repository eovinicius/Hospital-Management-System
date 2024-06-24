namespace Hospital.Domain.Shared;

public abstract class Entity
{
    protected Guid Id { get; private set; }
    protected DateTime CreatedAt { get; private set; }
    protected Entity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
    }
}
