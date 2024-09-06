using TruckEase.Exceptions;
using TruckEase.Utilities;

namespace TruckEase.ValueObjects;

public class LastNameValue
{
    private const int MaxLength = 200;

    [Newtonsoft.Json.JsonConstructor]
    private LastNameValue(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static implicit operator string(LastNameValue lastNameValue)
    {
        return lastNameValue.Value;
    }

    public static LastNameValue Create(string? value)
    {
        value = value?.Trim();
        if (string.IsNullOrEmpty(value))
        {
            throw new TruckEaseValidationException(ErrorCodes.LastNameInvalid);
        }

        if (value.Length > MaxLength)
        {
            throw new TruckEaseValidationException(ErrorCodes.LastNameInvalid);
        }

        return new LastNameValue(value);
    }
}
