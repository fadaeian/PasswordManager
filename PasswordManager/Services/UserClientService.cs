using PasswordManager.Base;
using PasswordManager.DTO;
using PasswordManager.Interfaces;
using System.Net.Http.Json;

namespace PasswordManager.Services
{
    public class UserClientService:IUserClientService
    {
        private HttpClient _ApiUrl;

        public UserClientService(HttpClient httpClient)
        {
            _ApiUrl = httpClient;
        }

        public async Task<ApiResultDTO<List<UserListItemDTO>>> GetUserList()
        {
            var result = await _ApiUrl.GetFromJsonAsync<ApiResultDTO<List<UserListItemDTO>>>($"https://localhost:7197/api/users");
            return result;
        }
    }
}
