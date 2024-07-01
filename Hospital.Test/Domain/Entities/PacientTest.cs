using FluentAssertions;
using Hospital.Domain.Entities;

namespace Hospital.Test.Domain.Entities;

public class PacientTest
{
    [Fact]
    public void Should_Create_Pacient()
    {
        var name = "John Doe";
        var document = "12345678900";
        var documentImage = "johndoe@hotmail.com";
        var Address = "123 Main St";

        var pacient = new Patient(name, document, documentImage, Address);

        pacient.Name.Should().Be(name);
        pacient.Document.Should().Be(document);
        pacient.DocumentImage.Should().Be(documentImage);
        pacient.Address.Should().Be(Address);
    }
}
