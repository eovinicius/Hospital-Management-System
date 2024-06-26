using Hospital.Domain.Shared;

namespace Hospital.Domain.Entities;

public class Appointment : AggregateRoot
{
    public string Description { get; private set; }
    public Guid SchedulingId { get; private set; }
    public Guid PatientId { get; private set; }
    public Guid DoctorId { get; private set; }
    public Guid? MedicalInsuranceId { get; private set; }
    public List<MedicalReport> MedicalReports { get; private set; }
    public Prescription? Prescription { get; private set; }

    public Appointment(string description, Guid patientId, Guid doctorId, Guid? medicalInsuranceId = null)
    {
        Description = description;
        PatientId = patientId;
        MedicalInsuranceId = medicalInsuranceId;
        DoctorId = doctorId;
        MedicalReports = [];
    }

    public static Appointment Create(string description, Guid patientId, Guid doctorId, Guid? medicalInsuranceId)
    {
        return new Appointment(description, patientId, doctorId, medicalInsuranceId);
    }

    public void AddMedicalReport(string diagnosis, string treatment, string recommendations)
    {
        MedicalReports.Add(new MedicalReport(diagnosis, treatment, recommendations));
    }

    public void AddPrescription(string medicine, string dosage, string duration)
    {
        if (Prescription == null)
        {
            Prescription = new Prescription();
        }
        Prescription.AddPrescribedMedication(medicine, dosage, duration);
    }
}
