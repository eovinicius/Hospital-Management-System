using Hospital.Domain.Entities;

namespace Hospital.Test.Domain.Entities;

public class MedicalInsuranceTest
{
    [Fact]
    public void Should_Create_MedicalInsurance()
    {
        var name = "Health Insurance";
        var policyNumber = "0000000";

        var medicalInsurance = new MedicalInsurance(name, policyNumber);

        Assert.Equal(name, medicalInsurance.Name);
        Assert.Equal(policyNumber, medicalInsurance.PolicyNumber);
        Assert.True(medicalInsurance.Active);
    }

    [Fact]
    public void Should_Create_MedicalInsurance_deactivated()
    {
        var name = "Health Insurance";
        var policyNumber = "0000000";
        var active = false;

        var medicalInsurance = new MedicalInsurance(name, policyNumber, active);

        Assert.Equal(name, medicalInsurance.Name);
        Assert.Equal(policyNumber, medicalInsurance.PolicyNumber);
        Assert.Equal(active, medicalInsurance.Active);
    }

    [Fact]
    public void Should_Activate_MedicalInsurance()
    {
        var name = "Health Insurance";
        var policyNumber = "0000000";
        var medicalInsurance = new MedicalInsurance(name, policyNumber, false);

        medicalInsurance.Activate();

        Assert.True(medicalInsurance.Active);
    }

    [Fact]
    public void Should_Deactivate_MedicalInsurance()
    {
        var name = "Health Insurance";
        var policyNumber = "0000000";
        var medicalInsurance = new MedicalInsurance(name, policyNumber);

        medicalInsurance.Deactivate();

        Assert.False(medicalInsurance.Active);
    }
}
