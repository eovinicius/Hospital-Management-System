using Hospital.Application.Dtos.input;
using Hospital.Domain.Entities;
using Hospital.Domain.Repositories;

namespace Hospital.Application.UseCases;

public class MakeAppointment
{
    private readonly IAppointmentRespository _appointmentRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IMedicalInsuranceRepository _medicalInsuranceRepository;

    public MakeAppointment(IAppointmentRespository appointmentRepository, IPatientRepository patientRepository, IDoctorRepository doctorRepository, IMedicalInsuranceRepository medicalInsuranceRepository)
    {
        _appointmentRepository = appointmentRepository;
        _patientRepository = patientRepository;
        _doctorRepository = doctorRepository;
        _medicalInsuranceRepository = medicalInsuranceRepository;
    }

    public async void Execute(MakeAppointmentInput input)
    {
        var patient = await _patientRepository.GetById(input.PatientId);
        if (patient == null)
        {
            throw new Exception("Patient not found");
        }
        var doctor = await _doctorRepository.GetById(input.DoctorId);
        if (doctor == null)
        {
            throw new Exception("Doctor not found");
        }

        var appointment = Appointment.Create(input.Date, input.Price, input.Description, input.PatientId, input.DoctorId, patient.MedicalInsuranceId);
        await _appointmentRepository.Add(appointment);
    }
}