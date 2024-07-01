using Hospital.Domain.Shared;

namespace Hospital.Domain.Entities;

public class InsurancePlan : AggregateRoot
{
    public string Name { get; private set; }
    public string Cnpj { get; set; }

    public InsurancePlan(string name, string cnpj)
    {
        Name = name;
        Cnpj = cnpj;
    }

    public static InsurancePlan Create(string name, string cnpj)
    {
        return new InsurancePlan(name, cnpj);
    }
}