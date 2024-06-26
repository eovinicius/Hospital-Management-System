using Hospital.Domain.Entities;
using Hospital.Domain.Shared;

namespace Hospital.Domain.Repositories;

public interface ISchedulingRepository : IRepositoryGeneric<Scheduling>
{
    Task<bool> IsDoctorAvailable(Guid doctorId, DateTime date);
}
