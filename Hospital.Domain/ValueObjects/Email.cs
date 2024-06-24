using System.Text.RegularExpressions;
using Hospital.Domain.Exceptions;
using Hospital.Domain.Shared;

namespace Hospital.Domain.ValueObjects;

public class Email : ValueObject
{
    public string Value { get; private set; }

    public Email(string value)
    {
        Value = value;
        Validate();
    }

    private void Validate()
    {
        Value = Value.Trim();
        string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        if (!Regex.IsMatch(Value, emailPattern))
        {
            throw new DomainException("Invalid email address");
        }
    }
}
