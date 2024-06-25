using Hospital.Application.Dtos.input;
using Hospital.Application.Services;
using Hospital.Domain.AbstractFactory;
using Hospital.Domain.Entities;
using Hospital.Domain.Repositories;
using Hospital.Domain.Services;

namespace Hospital.Application.Commands;

public class MedicalAppointment
{
    private readonly IAppointmentRespository _appointmentRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IMedicalInsuranceRepository _medicalInsuranceRepository;
    private readonly IUnitOfWork _uow;

    public MedicalAppointment(AbstractFactoryRepository factoryRepository, IUnitOfWork uow)
    {
        _appointmentRepository = factoryRepository.CreateAppointmentRepository();
        _patientRepository = factoryRepository.CreatePatientRepository();
        _doctorRepository = factoryRepository.CreateDoctorRepository();
        _medicalInsuranceRepository = factoryRepository.CreateMedicalInsuranceRepository();
        _uow = uow;
    }

    public async Task Execute(MedicalAppointmentInput input)
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
        var isDoctorAvailable = await _appointmentRepository.IsDoctorAvailable(input.DoctorId, input.Date);
        if (!isDoctorAvailable)
        {
            throw new Exception("Doctor not available");
        }
        var medicalInsurance = await _medicalInsuranceRepository.GetById(patient.MedicalInsuranceId);
        var priceWithDiscount = CalculateDiscount.Calculate(input.Price, medicalInsurance.Discount);
        var appointment = Appointment.Create(
            input.Date,
            priceWithDiscount,
            input.Price,
            input.Description,
            input.PatientId,
            input.DoctorId,
            patient.MedicalInsuranceId);
        await _appointmentRepository.Add(appointment);
        await _uow.Commit();
    }
}