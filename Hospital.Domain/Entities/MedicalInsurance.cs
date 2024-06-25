using Hospital.Domain.Shared;

namespace Hospital.Domain.Entities;

public class MedicalInsurance : AggregateRoot
{
    public string Name { get; private set; }
    public string PolicyNumber { get; set; }
    public decimal Discount { get; set; }
    public bool Active { get; private set; }

    public MedicalInsurance(string name, string policyNumber, bool active = true)
    {
        Name = name;
        PolicyNumber = policyNumber;
        Active = active;
    }

    public void Activate()
    {
        Active = true;
    }

    public void Deactivate()
    {
        Active = false;
    }
}