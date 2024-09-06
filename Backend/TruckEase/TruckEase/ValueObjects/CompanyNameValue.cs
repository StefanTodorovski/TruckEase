using TruckEase.Exceptions;
using TruckEase.Utilities;

namespace TruckEase.ValueObjects;


public class CompanyNameValue
{
    private const int MaxLength = 50;

    private CompanyNameValue(string? value)
    {
        Value = value;
    }

    public string? Value { get; }

    public static implicit operator string?(CompanyNameValue packageCodeValue)
    {
        return packageCodeValue.Value;
    }

    public static CompanyNameValue Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return new CompanyNameValue(null);
        }

        if (value.Length > MaxLength)
        {
            throw new TruckEaseValidationException(ErrorCodes.CompanyNameInvalidLength);
        }

        return new CompanyNameValue(value);
    }
}
