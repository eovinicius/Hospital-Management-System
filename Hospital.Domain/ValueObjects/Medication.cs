using Hospital.Domain.Shared;

namespace Hospital.Domain.ValueObjects;

public class Medication : ValueObject
{
    public string Name { get; private set; }
    public string Dosage { get; private set; }
    public string Duration { get; private set; }

    public Medication(string name, string dosage, string duration)
    {
        Name = name;
        Dosage = dosage;
        Duration = duration;
    }

    public bool Equals(Medication other)
    {
        return Name == other.Name && Dosage == other.Dosage && Duration == other.Duration;
    }
}
