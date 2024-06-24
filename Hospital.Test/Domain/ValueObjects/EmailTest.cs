using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Domain.Exceptions;
using Hospital.Domain.ValueObjects;
using Xunit;

namespace Hospital.Test.Domain.ValueObjects;

public class EmailTest
{
    [Fact]
    public void Should_Create_Email()
    {
        var address = "joedoe@gmail.com";

        var email = new Email(address);

        Assert.Equal(address, email.Value);
    }

    [Theory]
    [InlineData("")]
    [InlineData("joedoe")]
    [InlineData("joedoe@")]
    [InlineData("joedoe@gmail")]
    public void Should_Not_Create_Email(string address)
    {
        void act() => new Email(address);

        Assert.Throws<DomainException>(act);
    }
}
