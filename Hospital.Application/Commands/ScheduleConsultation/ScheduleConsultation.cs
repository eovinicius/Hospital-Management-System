using Hospital.Application.Services;
using Hospital.Domain.AbstractFactory;
using Hospital.Domain.Entities;
using Hospital.Domain.Repositories;

namespace Hospital.Application.Commands.MedicalScheduling;

public class ScheduleConsultation
{
    private readonly ISchedulingRepository _scheduleRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IInsurancePlanRepository _medicalInsuranceRepository;
    private readonly IUnitOfWork _uow;

    public ScheduleConsultation(AbstractFactoryRepository factoryRepository, IUnitOfWork uow)
    {
        _scheduleRepository = factoryRepository.CreateSchedulingRepository();
        _patientRepository = factoryRepository.CreatePatientRepository();
        _doctorRepository = factoryRepository.CreateDoctorRepository();
        _medicalInsuranceRepository = factoryRepository.CreateInsurancePlanRepository();
        _uow = uow;
    }

    public async Task Execute(ScheduleConsultationInput input)
    {
        var patient = await _patientRepository.FindById(input.PatientId);
        if (patient == null)
        {
            throw new Exception("Patient not found");
        }
        var doctor = await _doctorRepository.FindById(input.DoctorId);
        if (doctor == null)
        {
            throw new Exception("Doctor not found");
        }
        var isDoctorAvailable = await _scheduleRepository.IsDoctorAvailable(input.DoctorId, input.Date);
        if (!isDoctorAvailable)
        {
            throw new Exception("Doctor not available");
        }
        var appointment = Scheduling.Create(
            input.Date,
            input.Price,
            input.Description,
            input.PatientId,
            input.DoctorId,
            patient.InsurancePlanId,
            input.SchedulingType);
        await _scheduleRepository.Add(appointment);
        await _uow.Commit();
    }
}