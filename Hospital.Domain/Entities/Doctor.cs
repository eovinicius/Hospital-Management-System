using Hospital.Domain.Enums;
using Hospital.Domain.Shared;
using Hospital.Domain.ValueObjects;

namespace Hospital.Domain.Entities;

public class Doctor : AggregateRoot
{
    public string Name { get; private set; }
    public CRM CRM { get; private set; }
    public string ImageCRM { get; private set; }
    public Phone Phone { get; private set; }
    public string Address { get; private set; }
    public Specialty Specialty { get; private set; }

    public Doctor(string name, string crm, string imageCRM, string phone, string address, Specialty specialty)
    {
        Name = name;
        CRM = new CRM(crm);
        ImageCRM = imageCRM;
        Phone = new Phone(phone);
        Address = address;
        Specialty = specialty;
    }
}
