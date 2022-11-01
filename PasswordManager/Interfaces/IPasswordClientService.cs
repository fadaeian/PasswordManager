using PasswordManager.DTO;

namespace PasswordManager.Interfaces
{
    public interface IPasswordClientService
    {
        Task<ApiResultDTO<List<PasswordListItemDTO>>> GetPasswordList();
        //Task<ApiResultDTO<EditPasswordDTO>> GetPasswordDetail(string id);
        //Task<ApiResultDTO<bool>> UpdatePassword(EditPasswordDTO input);
        //Task<ApiResultDTO<bool>> CreatePassword(CreatePasswordDTO input);
        //Task<ApiResultDTO<bool>> DeletePassword(PasswordListItemDTO input);
    }
}
