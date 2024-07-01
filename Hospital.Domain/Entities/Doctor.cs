using Hospital.Domain.Enums;
using Hospital.Domain.Shared;
using Hospital.Domain.ValueObjects;

namespace Hospital.Domain.Entities;

public class Doctor : AggregateRoot
{
    public string Name { get; private set; }
    public Crm Crm { get; private set; }
    public string CrmImage { get; private set; }
    public List<Specialty> Specialty { get; private set; }

    public Doctor(string name, string crm)
    {
        Name = name;
        Crm = new Crm(crm);
        CrmImage = string.Empty;
        Specialty = [];
    }

    public static Doctor Create(string name, string crm)
    {
        return new Doctor(name, crm);
    }

    public void AddSpecialty(Specialty specialty)
    {
        Specialty.Add(specialty);
    }

    public void AddCrmImage(string crmImage)
    {
        CrmImage = crmImage;
    }

}
