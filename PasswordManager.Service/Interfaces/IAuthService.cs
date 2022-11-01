using PasswordManager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Service.Interfaces
{
    public interface IAuthService
    {
        Task<ApiResultDTO<string>> Login(LoginDTO input);
        string CreateJWTToken(string userName);
    }
}
