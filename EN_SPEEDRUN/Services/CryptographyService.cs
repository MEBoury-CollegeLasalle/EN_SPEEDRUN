using EN_SPEEDRUN.DataAccess.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.Services;
public class CryptographyService {
    private const int _saltSize = 16; // 128 bits
    private const int _keySize = 32; // 256 bits
    private const int _iterations = 100000;
    private const char _segmentDelimiter = ':';
    private static readonly HashAlgorithmName _algorithm = HashAlgorithmName.SHA256;

    private static CryptographyService INSTANCE;

    private CryptographyService() { }

    public static CryptographyService GetInstance() {
        return INSTANCE ??= new CryptographyService();
    }

    public bool ValidatePassword(string passwordToTest, UserDTO user) {
        string hash = user.PasswordHash;
        string[] segments = hash.Split(_segmentDelimiter);
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
        byte[] salt = RandomNumberGenerator.GetBytes(_saltSize);
        byte[] key = Rfc2898DeriveBytes.Pbkdf2(
            clearPassword,
            salt,
            _iterations,
            _algorithm,
            _keySize
        );
        return string.Join(
            _segmentDelimiter,
            Convert.ToHexString(key),
            Convert.ToHexString(salt),
            _iterations,
            _algorithm
        );
    }
}
