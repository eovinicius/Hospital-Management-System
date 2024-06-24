using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Domain.Entities;
using Hospital.Domain.Enums;
using Hospital.Domain.ValueObjects;
using Xunit;

namespace Hospital.Test.Domain.Entities;

public class DoctorTest
{
    [Fact]
    public void Should_Create_Doctor()
    {
        var name = "John Doe";
        var crm = "1234567";
        var phone = "11999999999";
        var address = "123 Main St";
        var specialty = Specialty.Surgery;

        var doctor = new Doctor(name, crm, phone, address, specialty);

        Assert.Equal(name, doctor.Name);
        Assert.Equal(crm, doctor.CRM.Value);
        Assert.Equal(phone, doctor.Phone.Value);
        Assert.Equal(address, doctor.Address);
        Assert.Equal(specialty, doctor.Specialty);
    }
}
