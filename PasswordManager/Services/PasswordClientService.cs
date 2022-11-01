using PasswordManager.Base;
using PasswordManager.DTO;
using PasswordManager.Interfaces;
using System.Net.Http.Json;

namespace PasswordManager.Services
{
	public class PasswordClientService : IPasswordClientService
    {
        private HttpClient _ApiUrl;

        public PasswordClientService(HttpClient httpClient)
        {
            _ApiUrl = httpClient;
        }


        public async Task<ApiResultDTO<List<PasswordListItemDTO>>> GetPasswordList()
        {
            var result = await _ApiUrl.GetFromJsonAsync<ApiResultDTO<List<PasswordListItemDTO>>>($"{BaseApiInfo.ApiAddress}api/passwords");
            return result;
        }

    }
}
