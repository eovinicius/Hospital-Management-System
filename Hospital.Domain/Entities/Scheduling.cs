using Hospital.Domain.Enums;
using Hospital.Domain.Shared;

namespace Hospital.Domain.Entities;

public class Scheduling : AggregateRoot
{
    public DateTime Date { get; private set; }
    public decimal PriceWithDiscount { get; private set; }
    public decimal Price { get; private set; }
    public string Description { get; private set; }
    public Guid PatientId { get; private set; }
    public Guid DoctorId { get; private set; }
    public Guid? MedicalInsuranceId { get; private set; }
    public TypeScheduling TypeScheduling { get; private set; }

    public Scheduling(DateTime date, decimal priceWithDiscount, decimal price, string description, Guid patientId, Guid doctorId, Guid? medicalInsuranceId, TypeScheduling typeScheduling)
    {
        Date = date;
        PriceWithDiscount = priceWithDiscount;
        Price = price;
        Description = description;
        PatientId = patientId;
        DoctorId = doctorId;
        MedicalInsuranceId = medicalInsuranceId;
        TypeScheduling = typeScheduling;
    }

    public static Scheduling Create(DateTime date, decimal priceWithDiscount, decimal price, string description, Guid patientId, Guid doctorId, Guid? medicalInsuranceId, TypeScheduling typeScheduling)
    {
        return new Scheduling(date, priceWithDiscount, price, description, patientId, doctorId, medicalInsuranceId, typeScheduling);
    }
}
