using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Service.Interfaces
{
    public interface IAuthService
    {
        string CreateJWTToken(string userName, string secretKey);
    }
}
