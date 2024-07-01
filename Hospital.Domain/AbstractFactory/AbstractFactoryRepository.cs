using Hospital.Domain.Repositories;

namespace Hospital.Domain.AbstractFactory;

public interface AbstractFactoryRepository
{
    IDoctorRepository CreateDoctorRepository();
    IPatientRepository CreatePatientRepository();
    IAppointmentRespository CreateAppointmentRepository();
    IInsurancePlanRepository CreateInsurancePlanRepository();
    ISchedulingRepository CreateSchedulingRepository();
}
