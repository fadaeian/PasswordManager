using PasswordManager.DTO;

namespace PasswordManager.Interfaces
{
    public interface IUserClientService
    {
        Task<ApiResultDTO<List<UserListItemDTO>>> GetUserList();
    }
}
