using System.Text.RegularExpressions;
using Hospital.Domain.Shared;

namespace Hospital.Domain.ValueObjects;

public class Phone : ValueObject
{
    public string Value { get; private set; }

    public Phone(string number)
    {
        Value = number;
        Validate();
    }

    private void Validate()
    {
        Value = Value.Trim();
        if (!Regex.IsMatch(Value, @"^\d{11}$"))
        {
            throw new ArgumentException($"Número de telefone inválido: {Value}");
        }
    }

    public string Format()
    {
        return $"({Value.Substring(0, 2)}){Value.Substring(2, 5)}-{Value.Substring(7)}";
    }
}
