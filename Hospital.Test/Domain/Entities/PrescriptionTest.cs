using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Domain.Entities;
using Xunit;

namespace Hospital.Test.Domain.Entities;

public class PrescriptionTest
{
    [Fact]
    public void Should_create_prescription()
    {
        var notes = "Notes";

        var prescription = new Prescription(notes);

        Assert.Equal(notes, prescription.Notes);
        Assert.Empty(prescription.Medications);
    }

    [Fact]
    public void Should_add_prescribed_medication()
    {
        var prescription = new Prescription();

        var medicine = "Medicine";
        var dosage = "Dosage";
        var duration = "Duration";

        prescription.AddPrescribedMedication(medicine, dosage, duration);

        Assert.Single(prescription.Medications);
        Assert.Equal(medicine, prescription.Medications.First().Name);
        Assert.Equal(dosage, prescription.Medications.First().Dosage);
        Assert.Equal(duration, prescription.Medications.First().Duration);
    }
}
