using Hospital.Application.Services;
using Hospital.Domain.AbstractFactory;
using Hospital.Domain.Entities;
using Hospital.Domain.Repositories;

namespace Hospital.Application.Commands.MedicalAppointment;

public class MedicalAppointment
{
    private readonly IPatientRepository _patientRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IAppointmentRespository _appointmentRepository;
    private readonly IUnitOfWork _uow;

    public MedicalAppointment(AbstractFactoryRepository factory, IUnitOfWork uow)
    {
        _appointmentRepository = factory.CreateAppointmentRepository();
        _patientRepository = factory.CreatePatientRepository();
        _doctorRepository = factory.CreateDoctorRepository();
        _uow = uow;
    }

    public async Task Execute(MedicalAppointmentInput input)
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
        var appointment = Appointment.Create(input.Description, input.PatientId, input.DoctorId, patient.InsurancePlanId);
        foreach (var medicalReport in input.MedicalReportInputs)
        {
            appointment.AddMedicalReport(medicalReport.Diagnosis, medicalReport.Treatment, medicalReport.Recommendations);
        }
        await _appointmentRepository.Add(appointment);
        await _uow.Commit();
    }
}
