using EN_SPEEDRUN.DataAccess.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.Services.Services;
public class CryptographyService {
    private const int SALT_SIZE = 16; // 128 bits
    private const int KEY_SIZE = 32; // 256 bits
    private const int ITERATIONS = 100000;
    private const char SEGMENT_DELIMITER = ':';
    private static readonly HashAlgorithmName ALGORITHM = HashAlgorithmName.SHA256;

    private static CryptographyService INSTANCE = null!;

    private CryptographyService() { }

    public static CryptographyService GetInstance() {
        return INSTANCE ??= new CryptographyService();
    }

    public bool ValidatePassword(string passwordToTest, string hash) {
        string[] segments = hash.Split(SEGMENT_DELIMITER);
        byte[] key = Convert.FromHexString(segments[0]);
        byte[] salt = Convert.FromHexString(segments[1]);
        int iterations = int.Parse(segments[2]);
        HashAlgorithmName algorithm = new HashAlgorithmName(segments[3]);
        byte[] inputSecretKey = Rfc2898DeriveBytes.Pbkdf2(
            passwordToTest,
            salt,
            iterations,
            algorithm,
            key.Length
        );
        return key.SequenceEqual(inputSecretKey);
    }


    public string HashPassword(string clearPassword) {
        byte[] salt = RandomNumberGenerator.GetBytes(SALT_SIZE);
        byte[] key = Rfc2898DeriveBytes.Pbkdf2(
            clearPassword,
            salt,
            ITERATIONS,
            ALGORITHM,
            KEY_SIZE
        );
        return string.Join(
            SEGMENT_DELIMITER,
            Convert.ToHexString(key),
            Convert.ToHexString(salt),
            ITERATIONS,
            ALGORITHM
        );
    }
}
