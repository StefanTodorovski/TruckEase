using System.Text.RegularExpressions;
using TruckEase.Exceptions;
using TruckEase.Utilities;

namespace TruckEase.ValueObjects;

public class EmailValue
{
    private const string EmailAddressRegex =
        @"^[\w-.%+/]+@([\w-]+\.)+[\w-]*$";

    [Newtonsoft.Json.JsonConstructor]
    private EmailValue(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static implicit operator string(EmailValue emailValue)
    {
        return emailValue.Value;
    }

    public static EmailValue Create(string? value)
    {
        value = value?.Trim();

        if (string.IsNullOrEmpty(value))
        {
            throw new TruckEaseValidationException(ErrorCodes.EmailEmpty);
        }

        Regex regex = new Regex(EmailAddressRegex, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(10));
        if (!regex.IsMatch(value))
        {
            throw new TruckEaseValidationException(ErrorCodes.EmailInvalidFormat);
        }

        return new EmailValue(value.ToLowerInvariant());
    }
}