using Hospital.Application.Dtos.input;
using Hospital.Domain.AbstractFactory;
using Hospital.Domain.Entities;
using Hospital.Domain.Repositories;
using Hospital.Domain.Services;

namespace Hospital.Application.UseCases;

public class MakeAppointment
{
    private readonly IAppointmentRespository _appointmentRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IMedicalInsuranceRepository _medicalInsuranceRepository;

    public MakeAppointment(AbstractFactoryRepository factoryRepository)
    {
        _appointmentRepository = factoryRepository.CreateAppointmentRepository();
        _patientRepository = factoryRepository.CreatePatientRepository();
        _doctorRepository = factoryRepository.CreateDoctorRepository();
        _medicalInsuranceRepository = factoryRepository.CreateMedicalInsuranceRepository();
    }

    public async Task Execute(MakeAppointmentInput input)
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
        var medicalInsurance = await _medicalInsuranceRepository.GetById(patient.MedicalInsuranceId);
        var priceWithDiscount = CalculateDiscount.Calculate(input.Price, medicalInsurance.Discount);
        var appointment = Appointment.Create(input.Date, priceWithDiscount, input.Price, input.Description, input.PatientId, input.DoctorId, patient.MedicalInsuranceId);
        await _appointmentRepository.Add(appointment);
    }
}