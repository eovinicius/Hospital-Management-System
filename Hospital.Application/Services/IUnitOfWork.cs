namespace Hospital.Application.Services;

public interface IUnitOfWork : IDisposable
{
    Task BeginTransaction();
    Task Commit();
    Task Rollback();
}
