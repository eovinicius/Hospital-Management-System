using Hospital.Domain.Shared;

namespace Hospital.Domain.Entities;

public class Report : Entity
{
    public string Diagnosis { get; private set; }
    public string Treatment { get; private set; }
    public string Recommendations { get; private set; }

    public Report(string diagnosis, string treatment, string recommendations)
    {
        Diagnosis = diagnosis;
        Treatment = treatment;
        Recommendations = recommendations;
    }

    public static Report Create(string diagnosis, string treatment, string recommendations)
    {
        return new Report(diagnosis, treatment, recommendations);
    }
}
