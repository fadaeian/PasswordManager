using PasswordManager.DTO;

namespace PasswordManager.Interfaces
{
    public interface ILoginClientService
    {
        Task<ApiResultDTO<string>> Login(LoginDTO input);
    }
}
