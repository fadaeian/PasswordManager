using PasswordManager.DTO;

namespace PasswordManager.Interfaces
{
    public interface IUserClientService
    {
        Task<ApiResultDTO<List<UserListItemDTO>>> GetUserList();
        Task<ApiResultDTO<EditUserDTO>> GetUserDetail(string id);
        Task<ApiResultDTO<bool>> UpdateUser(EditUserDTO input);
        Task<ApiResultDTO<bool>> CreateUser(CreateUserDTO input);
    }
}
