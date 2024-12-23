using System.Security.Cryptography;

namespace Infrastructure.Utils;

public class HashPassword
{
    private const int SaltSize = 16; // 128 bit
    private const int KeySize = 32; // 256 bit
    private const int Iterations = 10000;

    public static string Create(string password)
    {
        using var rng = new Rfc2898DeriveBytes(password, SaltSize, Iterations, HashAlgorithmName.SHA256);
        var salt = rng.Salt;
        var key = rng.GetBytes(KeySize);

        var hash = new byte[SaltSize + KeySize];
        Array.Copy(salt, 0, hash, 0, SaltSize);
        Array.Copy(key, 0, hash, SaltSize, KeySize);

        return Convert.ToBase64String(hash);
    }

    public static bool Verify(string hashedPassword, string password)
    {
        var hashBytes = Convert.FromBase64String(hashedPassword);
        var salt = new byte[SaltSize];
        Array.Copy(hashBytes, 0, salt, 0, SaltSize);

        using var rng = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
        var key = rng.GetBytes(KeySize);

        for (int i = 0; i < KeySize; i++)
        {
            if (key[i] != hashBytes[i + SaltSize])
                return false;
        }

        return true;
    }
}
