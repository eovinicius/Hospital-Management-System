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
    public SchedulingStatus Status { get; private set; }

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
    public void Finish()
    {
        if (Status == SchedulingStatus.Canceled)
        {
            throw new InvalidOperationException("Cannot finish a canceled appointment");
        }
        Status = SchedulingStatus.Finished;
    }

    public void Cancel()
    {
        if (Status == SchedulingStatus.Finished)
        {
            throw new InvalidOperationException("Cannot cancel a finished appointment");
        }
        Status = SchedulingStatus.Canceled;
    }

    public void Reschedule(DateTime newDate)
    {
        if (Status == SchedulingStatus.Finished)
        {
            throw new InvalidOperationException("Cannot reschedule a finished appointment.");
        }
        if (newDate <= DateTime.Now)
        {
            throw new ArgumentException("Cannot reschedule to a past date.");
        }
        if (newDate <= Date.AddDays(-2))
        {
            throw new ArgumentException("Rescheduling must be done at least 48 hours in advance.");
        }
        Date = newDate;
    }
}
