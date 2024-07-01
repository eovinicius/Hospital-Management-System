using Hospital.Domain.Shared;

namespace Hospital.Domain.Entities;

public class Appointment : AggregateRoot
{
    public string Description { get; private set; }
    public Guid PatientId { get; private set; }
    public Guid DoctorId { get; private set; }
    public Guid? InsurancePlanId { get; private set; }
    public List<Report> Reports { get; private set; }
    public List<Medicine> Medicines { get; private set; }

    public Appointment(string description, Guid patientId, Guid doctorId, Guid? insurancePlanId = null)
    {
        Description = description;
        PatientId = patientId;
        InsurancePlanId = insurancePlanId;
        DoctorId = doctorId;
        Reports = [];
        Medicines = [];
    }

    public static Appointment Create(string description, Guid patientId, Guid doctorId, Guid? medicalInsuranceId)
    {
        return new Appointment(description, patientId, doctorId, medicalInsuranceId);
    }

    public void AddReport(string diagnosis, string treatment, string recommendations)
    {
        var report = Report.Create(diagnosis, treatment, recommendations);
        Reports.Add(report);
    }

    public void AddMedicine(string name, string dosage, string frequency, string duration)
    {
        var medicine = Medicine.Create(name, dosage, frequency, duration);
        Medicines.Add(medicine);
    }
}
