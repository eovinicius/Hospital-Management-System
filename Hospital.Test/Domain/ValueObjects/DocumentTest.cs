using Hospital.Domain.ValueObjects;

namespace Hospital.Test.Domain.ValueObjects;

public class DocumentTest
{
    [Fact]
    public void Should_Create_Document()
    {
        var number = "12345678909";

        var document = new Document(number);

        Assert.Equal(number, document.Value);
    }

    [Theory]
    [InlineData("1234567890")]
    [InlineData("123456789012")]
    [InlineData("1234567890a")]
    public void Should_Throw_Exception_When_Create_Document_With_Invalid_Value(string number)
    {
        Assert.Throws<ArgumentException>(() => new Document(number));
    }
}
