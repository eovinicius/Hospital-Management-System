using Hospital.Domain.Shared;

namespace Hospital.Domain.Entities;

public class Medicine : Entity
{
    public string Name { get; private set; }
    public string Dosage { get; private set; }
    public string Frequency { get; private set; }
    public string Duration { get; private set; }

    public Medicine(string name, string dosage, string frequency, string duration)
    {
        Name = name;
        Dosage = dosage;
        Frequency = frequency;
        Duration = duration;
    }

    public static Medicine Create(string name, string dosage, string frequency, string duration)
    {
        return new Medicine(name, dosage, frequency, duration);
    }
}
