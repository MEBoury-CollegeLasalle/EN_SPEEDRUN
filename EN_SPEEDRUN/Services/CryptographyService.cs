using EN_SPEEDRUN.DataAccess.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.Services;
internal class CryptographyService {

    private static CryptographyService INSTANCE;

    private CryptographyService() { }

    public static CryptographyService GetInstance() {
        return INSTANCE ??= new CryptographyService();
    }

    public bool ValidatePassword(string passwordToTest, UserDTO user) {
        return this.HashPassword(passwordToTest).Equals(user.PasswordHash);
    }

    private string HashPassword(string clearPassword) {
        // TODO complete cryptographic funtion
    }
}
