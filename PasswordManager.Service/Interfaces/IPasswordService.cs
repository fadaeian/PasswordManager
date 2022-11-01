using PasswordManager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Service.Interfaces
{
    public interface IPasswordService
    {
        ApiResultDTO<List<PasswordListItemDTO>> GetAllPassword();
        ApiResultDTO<EditPasswordDTO> GetPasswordDetail(string id);
        ApiResultDTO<bool> UpdatePassword(EditPasswordDTO input);
        ApiResultDTO<bool> CreatePassword(CreatePasswordDTO input);
        ApiResultDTO<bool> DeletePassword(PasswordListItemDTO input);
    }
}
