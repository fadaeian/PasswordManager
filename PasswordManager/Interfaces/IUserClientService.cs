using PasswordManager.DTO;

namespace PasswordManager.Interfaces
{
    public interface IUserClientService
    {
        Task<ApiResultDTO<string>> GetUserToken();
        Task<ApiResultDTO<List<UserListItemDTO>>> GetUserList();
        Task<ApiResultDTO<EditUserDTO>> GetUserDetail(string id);
        Task<ApiResultDTO<bool>> UpdateUser(EditUserDTO input);
    }
}
