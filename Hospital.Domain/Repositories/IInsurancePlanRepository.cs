using Hospital.Domain.Entities;
using Hospital.Domain.Shared;

namespace Hospital.Domain.Repositories;

public interface IInsurancePlanRepository : IRepositoryGeneric<InsurancePlan>
{
    Task<InsurancePlan> FindByCnpj(string cnpj);
}
