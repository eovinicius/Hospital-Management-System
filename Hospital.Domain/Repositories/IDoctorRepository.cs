using Hospital.Domain.Entities;
using Hospital.Domain.Shared;

namespace Hospital.Domain.Repositories;

public interface IDoctorRepository : IRepositoryGeneric<Doctor>
{
    Task<Doctor> FindByCRM(string crm);
}
