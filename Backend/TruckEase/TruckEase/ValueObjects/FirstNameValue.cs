using TruckEase.Exceptions;
using TruckEase.Utilities;

namespace TruckEase.ValueObjects;

public class FirstNameValue
{
    private const int MaxLength = 200;

    [Newtonsoft.Json.JsonConstructor]
    private FirstNameValue(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static implicit operator string(FirstNameValue firstNameValue)
    {
        return firstNameValue.Value;
    }

    public static FirstNameValue Create(string? value)
    {
        value = value?.Trim();
        if (string.IsNullOrEmpty(value))
        {
            throw new TruckEaseValidationException(ErrorCodes.FirstNameInvalid);
        }

        if (value.Length > MaxLength)
        {
            throw new TruckEaseValidationException(ErrorCodes.FirstNameInvalid);
        }

        return new FirstNameValue(value);
    }
}
