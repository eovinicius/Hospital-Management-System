using Hospital.Application.Services;
using Hospital.Domain.AbstractFactory;
using Hospital.Domain.Entities;
using Hospital.Domain.Repositories;

namespace Hospital.Application.Commands.RegisterPatient;

public class RegisterPatient
{
    private readonly IPatientRepository _pacientRepository;
    private readonly IInsurancePlanRepository _insurancePlanRepository;
    private readonly IIamageStorage _imageStorage;
    private readonly IUnitOfWork _uow;

    public RegisterPatient(AbstractFactoryRepository factory, IUnitOfWork uow, IIamageStorage imageStorage)
    {
        _pacientRepository = factory.CreatePatientRepository();
        _insurancePlanRepository = factory.CreateInsurancePlanRepository();
        _imageStorage = imageStorage;
        _uow = uow;
    }

    public async Task Execute(RegisterPatientInput input)
    {
        var patientAlreadyExists = await _pacientRepository.GetByDocument(input.Document);
        if (patientAlreadyExists != null)
        {
            throw new InvalidOperationException("Patient already exists");
        }
        var patient = new Patient(input.Name, input.Document, input.Address);
        if (input.InsurancePlainId != null)
        {
            var insurancePlan = await _insurancePlanRepository.FindById((Guid)input.InsurancePlainId);
            if (insurancePlan == null)
            {
                throw new InvalidOperationException("Insurance plan not found");
            }
            patient.AddInsurancePlan(input.InsurancePlainId.Value);
        }
        patient.AddInsurancePlan(input.InsurancePlainId!.Value);
        string documentImage = await _imageStorage.Save(input.DocumentImage);
        patient.AddDocumentImage(documentImage);
        await _pacientRepository.Add(patient);
        await _uow.Commit();
    }
}
