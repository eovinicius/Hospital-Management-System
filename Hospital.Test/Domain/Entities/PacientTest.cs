using Hospital.Domain.Entities;

namespace Hospital.Test.Domain.Entities;

public class PacientTest
{
    [Fact]
    public void Should_Create_Pacient()
    {
        var name = "John Doe";
        var document = "12345678900";
        var email = "johndoe@hotmail.com";
        var phone = "11999999999";
        var address = "123 Main St";

        var pacient = new Patient(name, document, email, phone, address);

        Assert.Equal(name, pacient.Name);
        Assert.Equal(document, pacient.Document.Value);
        Assert.Equal(phone, pacient.Phone.Value);
        Assert.Equal(address, pacient.Address);
    }
}
