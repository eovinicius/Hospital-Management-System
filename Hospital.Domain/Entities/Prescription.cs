using Hospital.Domain.Shared;
using Hospital.Domain.ValueObjects;

namespace Hospital.Domain.Entities;

public class Prescription : Entity
{
    public List<Medication> Medications { get; private set; }
    public string Notes { get; private set; }

    public Prescription(string notes = "")
    {
        Medications = [];
        Notes = notes;
    }

    public void AddPrescribedMedication(string medicine, string dosage, string duration)
    {
        Medications.Add(new Medication(medicine, dosage, duration));
    }
}
