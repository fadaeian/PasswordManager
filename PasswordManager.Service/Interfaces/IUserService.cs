using PasswordManager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Service.Interfaces
{
    public interface IUserService
    {
        ApiResultDTO<List<UserListItemDTO>> GetAllUsers();
        ApiResultDTO<EditUserDTO> GetUserDetail(string id);
        ApiResultDTO<bool> UpdateUser(EditUserDTO input);
        ApiResultDTO<bool> CreateUser(CreateUserDTO input);
        ApiResultDTO<bool> DeleteUser(UserListItemDTO input);
    }
}
