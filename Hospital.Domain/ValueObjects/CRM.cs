using System.Text.RegularExpressions;
using Hospital.Domain.Exceptions;
using Hospital.Domain.Shared;

namespace Hospital.Domain.ValueObjects;

public class Crm : ValueObject
{
    public string Value { get; private set; }

    public Crm(string value)
    {
        Value = value;

        Validate();
    }

    private void Validate()
    {
        if (!Regex.IsMatch(Value, @"^\d{7}$"))
        {
            throw new DomainException("CRM should have 7 digits");
        }
    }

    public override string ToString()
    {
        return $"{Value.Substring(0, 2)}.{Value.Substring(2, 3)}.{Value.Substring(5)}";
    }
}
