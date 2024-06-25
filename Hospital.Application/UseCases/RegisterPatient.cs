
using Hospital.Application.Dtos.input;
using Hospital.Domain.Entities;
using Hospital.Domain.Repositories;

namespace Hospital.Application.UseCases;

public class RegisterPatient
{
    private readonly IPatientRepository _pacientRepository;

    public RegisterPatient(IPatientRepository pacientRepository)
    {
        _pacientRepository = pacientRepository;
    }

    public async Task Execute(RegisterPatientInput input)
    {
        var patientAlreadyExists = await _pacientRepository.GetByDocument(input.Document);
        if (patientAlreadyExists != null || patientAlreadyExists!.Email.Value == input.Email || patientAlreadyExists!.Phone.Value == input.Phone)
        {
            throw new InvalidOperationException("Patient already exists");
        }

        var patient = new Patient(input.Name, input.Document, input.Email, input.Phone, input.Address, input.MedicalInsuranceId);

        await _pacientRepository.Add(patient);
    }
}
