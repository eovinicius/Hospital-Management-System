using Hospital.Domain.Shared;
using Hospital.Domain.ValueObjects;

namespace Hospital.Domain.Entities;

public class Patient : AggregateRoot
{
    public string Name { get; private set; }
    public Document Document { get; private set; }
    public string DocumentImage { get; private set; }
    public Email Email { get; private set; }
    public Phone Phone { get; private set; }
    public string Address { get; private set; }
    public Guid? MedicalInsuranceId { get; private set; }

    public Patient(string name, string document, string documentImage, string email, string phone, string address, Guid? medicalInsuranceId = null)
    {
        Name = name;
        Document = new Document(document);
        Email = new Email(email);
        Phone = new Phone(phone);
        DocumentImage = documentImage;
        Address = address;
        MedicalInsuranceId = medicalInsuranceId;
    }
}
