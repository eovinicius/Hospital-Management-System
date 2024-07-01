using Hospital.Domain.Enums;
using Hospital.Domain.Shared;

namespace Hospital.Domain.Entities;

public class Scheduling : AggregateRoot
{
    public DateTime Date { get; private set; }
    public decimal Price { get; private set; }
    public string Description { get; private set; }
    public Guid PatientId { get; private set; }
    public Guid DoctorId { get; private set; }
    public Guid? InsuranceIdPlanId { get; private set; }
    public SchedulingStatus Status { get; private set; }
    public SchedulingType Type { get; private set; }

    public Scheduling(DateTime date, decimal price, string description, Guid patientId, Guid doctorId, Guid? insuranceIdPlanId, SchedulingType type)
    {
        Date = date;
        Price = price;
        Description = description;
        PatientId = patientId;
        DoctorId = doctorId;
        InsuranceIdPlanId = insuranceIdPlanId;
        Status = SchedulingStatus.Scheduled;
        Type = type;

        Validate();
    }

    public static Scheduling Create(DateTime date, decimal price, string description, Guid patientId, Guid doctorId, Guid? insuranceIdPlanId, SchedulingType type)
    {
        return new Scheduling(date, price, description, patientId, doctorId, insuranceIdPlanId, type);
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
        if (Status != SchedulingStatus.Scheduled)
        {
            throw new InvalidOperationException("Cannot cancel a finished appointment.");
        }
        Status = SchedulingStatus.Canceled;
    }

    public void Reschedule(DateTime newDate)
    {
        if (Status != SchedulingStatus.Scheduled)
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

    private void Validate()
    {
        if (Date <= DateTime.Now)
        {
            throw new ArgumentException("Date must be in the future.");
        }
        if (Price <= 0)
        {
            throw new ArgumentException("Price must be greater than zero.");
        }
        if (string.IsNullOrWhiteSpace(Description))
        {
            throw new ArgumentException("Description cannot be empty.");
        }
    }
}