using Hospital.Domain.Repositories;

namespace Hospital.Domain.AbstractFactory;

public abstract class AbstractFactoryRepository
{
    public abstract IDoctorRepository CreateDoctorRepository();
    public abstract IPatientRepository CreatePatientRepository();
    public abstract IAppointmentRespository CreateAppointmentRepository();
    public abstract IMedicalInsuranceRepository CreateMedicalInsuranceRepository();
}
