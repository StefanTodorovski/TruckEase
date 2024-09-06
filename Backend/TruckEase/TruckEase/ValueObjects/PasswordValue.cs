using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using TruckEase.Exceptions;
using TruckEase.Utilities;

namespace TruckEase.ValueObjects;

public class PasswordValue
{
    private const int IterationCount = 1000;
    private const int RequestedHashBytes = 64;
    private const int SaltLength = 16;
    private const int MinPasswordLength = 6;

    [Newtonsoft.Json.JsonConstructor]
    private PasswordValue(string hash, string salt)
    {
        Hash = hash;
        Salt = salt;
    }

    public string Hash { get; private set; }

    public string Salt { get; private set; }

#pragma warning disable S3875 // "operator==" should not be overloaded on reference types
    public static bool operator ==(PasswordValue lhs, PasswordValue rhs)
#pragma warning restore S3875 // "operator==" should not be overloaded on reference types
    {
        return lhs.Hash == rhs.Hash;
    }

    public static bool operator !=(PasswordValue lhs, PasswordValue rhs)
    {
        return !(lhs == rhs);
    }

    public static PasswordValue Create(string password)
    {
        ValidatePassword(password);

        byte[] salt = Guid.NewGuid().ToByteArray();

        return GenerateSaltedHash(password, salt);
    }

    public static PasswordValue CreateFromGuess(string password, byte[] salt)
    {
        ValidatePassword(password);

        if (salt.Length != SaltLength)
        {
            throw new TruckEaseValidationException(ErrorCodes.PasswordSaltInvalidLength);
        }

        return GenerateSaltedHash(password, salt);
    }

    public static PasswordValue CreateFromHash(string saltedPasswordHash, string passwordSalt)
    {
        return new PasswordValue(saltedPasswordHash, passwordSalt);
    }

    public override bool Equals(object obj)
    {
        PasswordValue passwordValue = obj as PasswordValue;

        if (passwordValue == null)
        {
            return false;
        }

        return this == passwordValue;
    }

    public override int GetHashCode()
    {
        return Hash.GetHashCode(StringComparison.InvariantCulture);
    }

    private static PasswordValue GenerateSaltedHash(string password, byte[] salt)
    {
        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA512,
            iterationCount: IterationCount,
            numBytesRequested: RequestedHashBytes));

        return new PasswordValue(hashed, new Guid(salt).ToString());
    }

    private static void ValidatePassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new TruckEaseValidationException(ErrorCodes.PasswordInvalid);
        }

        if (password.Length < MinPasswordLength)
        {
            throw new TruckEaseValidationException(ErrorCodes.PasswordInvalid);
        }
    }
}
