namespace Hospital.Application.Services;

public interface IUnitOfWork : IDisposable
{
    Task Commit();
}
