namespace TruckEase.ValueObjects;

using TruckEase.Exceptions;
using TruckEase.Utilities;

public class CompanyRegistrationNumberValue
{
    private const int MaxLength = 50;

    private CompanyRegistrationNumberValue(string? value)
    {
        Value = value;
    }

    public string? Value { get; }

    public static implicit operator string?(CompanyRegistrationNumberValue packageCodeValue)
    {
        return packageCodeValue.Value;
    }

    public static CompanyRegistrationNumberValue Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return new CompanyRegistrationNumberValue(null);
        }

        if (value.Length > MaxLength)
        {
            throw new TruckEaseValidationException(ErrorCodes.CompanyRegistrationNumberInvalidLength);
        }

        return new CompanyRegistrationNumberValue(value);
    }
}
