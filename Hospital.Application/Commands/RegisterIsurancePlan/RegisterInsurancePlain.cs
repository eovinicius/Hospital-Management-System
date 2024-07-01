using Hospital.Application.Commands.RegisterIsurencePlan;
using Hospital.Application.Services;
using Hospital.Domain.AbstractFactory;
using Hospital.Domain.Entities;
using Hospital.Domain.Repositories;

namespace Hospital.Application.Commands.RegisterIsurancePlan;

public class RegisterIsurancePlain
{
    private readonly IInsurancePlanRepository _insurancePlanRepository;
    private readonly IUnitOfWork _unitOfWork;
    public RegisterIsurancePlain(AbstractFactoryRepository abstractFactoryRepository, IUnitOfWork unitOfWork)
    {
        _insurancePlanRepository = abstractFactoryRepository.CreateInsurancePlanRepository();
        _unitOfWork = unitOfWork;
    }

    public async void Execute(RegisterInsurancePlainInput input)
    {
        var insurancePlanIsAlreayExiste = await _insurancePlanRepository.FindByCnpj(input.Cnpj);
        if (insurancePlanIsAlreayExiste != null)
        {
            throw new Exception("Insurance plan already exists");
        }
        var insurancePlan = new InsurancePlan(input.Name, input.Cnpj);
        await _insurancePlanRepository.Add(insurancePlan);
        await _unitOfWork.Commit();
    }
}

