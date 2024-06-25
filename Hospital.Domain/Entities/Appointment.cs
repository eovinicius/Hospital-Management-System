using Hospital.Domain.Enums;
using Hospital.Domain.Shared;

namespace Hospital.Domain.Entities;

public class Appointment : AggregateRoot
{
    public DateTime Date { get; private set; }
    public decimal Price { get; private set; }
    public decimal FinalPrice { get; private set; }
    public string Description { get; private set; }
    public Guid PatientId { get; private set; }
    public Guid DoctorId { get; private set; }
    public Guid? MedicalInsuranceId { get; private set; }
    public List<MedicalReport> MedicalReports { get; private set; }
    public Prescription? Prescription { get; private set; }
    public AppointmentStatus Status { get; private set; }

    public Appointment(DateTime date, decimal price, decimal FinalPrince, string description, Guid patientId, Guid doctorId, Guid? medicalInsuranceId = null)
    {
        Date = date;
        Price = price;
        FinalPrice = FinalPrince;
        Description = description;
        PatientId = patientId;
        MedicalInsuranceId = medicalInsuranceId;
        DoctorId = doctorId;
        MedicalReports = [];
        Status = AppointmentStatus.Scheduled;
    }

    public static Appointment Create(DateTime date, decimal price, decimal FinalPrice, string description, Guid patientId, Guid doctorId, Guid? medicalInsuranceId)
    {
        if (date <= DateTime.Now)
        {
            throw new ArgumentException("Cannot schedule an appointment for a past date.");
        }

        return new Appointment(date, price, FinalPrice, description, patientId, doctorId, medicalInsuranceId);
    }

    public void AddMedicalReport(string diagnosis, string treatment, string recommendations)
    {
        if (Status == AppointmentStatus.Finished || Status == AppointmentStatus.Canceled)
        {
            throw new InvalidOperationException("Cannot reschedule a finished or canceled appointment");
        }
        MedicalReports.Add(new MedicalReport(diagnosis, treatment, recommendations));
    }

    public void AddPrescription(string medicine, string dosage, string duration)
    {
        if (Status == AppointmentStatus.Finished || Status == AppointmentStatus.Canceled)
        {
            throw new InvalidOperationException("Cannot reschedule a finished or canceled appointment");
        }
        if (Prescription == null)
        {
            Prescription = new Prescription();
        }
        Prescription.AddPrescribedMedication(medicine, dosage, duration);
    }

    public void Reschedule(DateTime newDate)
    {
        if (Status == AppointmentStatus.Finished)
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

    public void Finish()
    {
        if (Status == AppointmentStatus.Canceled)
        {
            throw new InvalidOperationException("Cannot finish a canceled appointment");
        }
        Status = AppointmentStatus.Finished;
    }

    public void Cancel()
    {
        if (Status == AppointmentStatus.Finished)
        {
            throw new InvalidOperationException("Cannot cancel a finished appointment");
        }
        Status = AppointmentStatus.Canceled;
    }

    public void CalculeDiscount(decimal discount)
    {
        FinalPrice = Price * discount;
    }
}
