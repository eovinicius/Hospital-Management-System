using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Domain.ValueObjects;
using Xunit;

namespace Hospital.Test.Domain.ValueObjects;

public class PhoneTest
{
    [Fact]
    public void Should_Create_Phone()
    {
        var number = "11948473792";

        var phone = new Phone(number);

        Assert.Equal(number, phone.Value);
    }

    [Theory]
    [InlineData("11948473")]
    [InlineData("000")]
    [InlineData("")]
    [InlineData("119484737923")]
    public void Should_Throw_Exception_When_Phone_Is_Invalid(string number)
    {
        Assert.Throws<ArgumentException>(() => new Phone(number));
    }
}