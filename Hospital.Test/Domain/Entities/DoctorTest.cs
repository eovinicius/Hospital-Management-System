using FluentAssertions;
using Hospital.Domain.Entities;
using Hospital.Domain.Enums;

namespace Hospital.Test.Domain.Entities;

public class DoctorTest
{
    [Fact]
    public void Should_Create_Doctor()
    {
        var name = "John Doe";
        var crm = "1234567";
        var crmImage = "image.jpg";
        var specialty = Specialty.Surgery;

        var doctor = Doctor.Create(name, crm, crmImage, specialty);

        doctor.Name.Should().Be(name);
        doctor.Crm.Should().Be(crm);
        doctor.CrmImage.Should().Be(crmImage);
        doctor.Specialty.Should().Contain(specialty);
    }
}
