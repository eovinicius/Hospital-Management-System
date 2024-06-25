using Hospital.Domain.Entities;
using Hospital.Domain.Shared;

namespace Hospital.Domain.Repositories;

public interface IAppointmentRespository : IRepositoryGeneric<Appointment>
{
    Task<bool> IsDoctorAvailable(Guid doctorId, DateTime date);
}
