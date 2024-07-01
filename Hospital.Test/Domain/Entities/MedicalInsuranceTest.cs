using FluentAssertions;
using Hospital.Domain.Entities;

namespace Hospital.Test.Domain.Entities;

public class InsurancePlainTest
{
    [Fact]
    public void Should_Create_MedicalInsurance()
    {
        var name = "Health Insurance";
        var cnpj = "0000000";

        var insurancePlan = new InsurancePlan(name, cnpj);

        insurancePlan.Name.Should().Be(name);
        insurancePlan.Cnpj.Should().Be(cnpj);
    }
}
