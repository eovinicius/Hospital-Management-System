using System.Text.RegularExpressions;
using Hospital.Domain.Shared;

namespace Hospital.Domain.ValueObjects;

public class Document : ValueObject
{
    public string Value { get; private set; }

    public Document(string value)
    {
        Value = value;

        Validate();
    }

    private void Validate()
    {
        Value = Value.Trim();
        if (!Regex.IsMatch(Value, @"^\d{11}$"))
        {
            throw new ArgumentException("Invalid CPF");
        }
    }

    public string Format()
    {
        return $"{Value.Substring(0, 3)}.{Value.Substring(3, 3)}.{Value.Substring(6, 3)}-{Value.Substring(9)}";
    }
}
