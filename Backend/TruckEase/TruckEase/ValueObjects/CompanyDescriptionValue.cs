namespace TruckEase.ValueObjects;

using TruckEase.Exceptions;
using TruckEase.Utilities;

public class CompanyDescriptionValue
{
    private const int MaxLength = 50;

    private CompanyDescriptionValue(string? value)
    {
        Value = value;
    }

    public string? Value { get; }

    public static implicit operator string?(CompanyDescriptionValue packageCodeValue)
    {
        return packageCodeValue.Value;
    }

    public static CompanyDescriptionValue Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return new CompanyDescriptionValue(null);
        }

        if (value.Length > MaxLength)
        {
            throw new TruckEaseValidationException(ErrorCodes.CompanyDescriptionInvalidLength);
        }

        return new CompanyDescriptionValue(value);
    }
}