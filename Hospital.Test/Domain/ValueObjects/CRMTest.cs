using Hospital.Domain.Exceptions;
using Hospital.Domain.ValueObjects;

namespace Hospital.Test.Domain.ValueObjects;

public class CRMTest
{
    [Fact]
    public void Should_Create_CRM()
    {
        var number = "1234567";

        var crm = new Crm(number);

        Assert.Equal(number, crm.Value);
    }

    [Theory]
    [InlineData("")]
    [InlineData("123456")]
    [InlineData("12345678")]
    public void Should_Not_Create_CRM(string number)
    {
        void act() => new Crm(number);
    }
}
