using Hospital.Domain.Exceptions;
using Hospital.Domain.Shared;

namespace Hospital.Domain.Entities;

public class MedicalReport : Entity
{
    public string Diagnosis { get; private set; }
    public string Treatment { get; private set; }
    public string Recommendations { get; private set; }

    public MedicalReport(string diagnosis, string treatment, string recommendations)
    {
        Diagnosis = diagnosis;
        Treatment = treatment;
        Recommendations = recommendations;
    }

    public void Update(string diagnosis, string treatment, string recommendations)
    {
        Diagnosis = diagnosis;
        Treatment = treatment;
        Recommendations = recommendations;
    }

    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(Diagnosis))
        {
            throw new DomainException("Diagnosis is required.");
        }

        if (string.IsNullOrWhiteSpace(Treatment))
        {
            throw new DomainException("Treatment is required.");
        }

        if (string.IsNullOrWhiteSpace(Recommendations))
        {
            throw new DomainException("Recommendations is required.");
        }
    }
}
