using Hospital.Domain.Shared;
using Hospital.Domain.ValueObjects;

namespace Hospital.Domain.Entities;

public class Patient : AggregateRoot
{
    public string Name { get; private set; }
    public Document Document { get; private set; }
    public string DocumentImage { get; private set; }
    public string Address { get; private set; }
    public Guid? InsurancePlanId { get; private set; }

    public Patient(string name, string document, string address)
    {
        Name = name;
        Document = new Document(document);
        Address = address;
        DocumentImage = string.Empty;
    }

    public static Patient Create(string name, string document, string address)
    {
        return new Patient(name, document, address);
    }

    public void AddInsurancePlan(Guid insurancePlanId)
    {
        InsurancePlanId = insurancePlanId;
    }

    public void AddDocumentImage(string image)
    {
        DocumentImage = image;
    }
}
