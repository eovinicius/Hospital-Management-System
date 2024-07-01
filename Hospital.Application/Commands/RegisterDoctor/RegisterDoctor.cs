using Hospital.Application.Services;
using Hospital.Domain.AbstractFactory;
using Hospital.Domain.Entities;
using Hospital.Domain.Repositories;

namespace Hospital.Application.Commands.RegisterDoctor;

public class RegisterDoctor
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IIamageStorage iamageStorage;
    private readonly IUnitOfWork _uow;

    public RegisterDoctor(AbstractFactoryRepository factory, IUnitOfWork uow, IIamageStorage iamageStorage)
    {
        _doctorRepository = factory.CreateDoctorRepository();
        this.iamageStorage = iamageStorage;
        _uow = uow;
    }

    public async Task Execute(RegisterDoctorInput input)
    {
        var doctorAlreadyExists = await _doctorRepository.FindByCRM(input.Crm);
        if (doctorAlreadyExists != null)
        {
            throw new Exception("Doctor already exists");
        }
        var doctor = new Doctor(input.Name, input.Crm);
        foreach (var specialty in input.Specialty)
        {
            doctor.AddSpecialty(specialty);
        }
        string documentImage = await iamageStorage.Save(input.CrmImage);
        doctor.AddCrmImage(documentImage);
        await _doctorRepository.Add(doctor);
        await _uow.Commit();
    }
}
