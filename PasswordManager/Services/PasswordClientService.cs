using Newtonsoft.Json;
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
        public async Task<ApiResultDTO<EditPasswordDTO>> GetPasswordDetail(string id)
        {
            var result = await _ApiUrl.GetFromJsonAsync<ApiResultDTO<EditPasswordDTO>>($"{BaseApiInfo.ApiAddress}api/PasswordDetail?id={id}");
            return result;
        }

        public async Task<ApiResultDTO<bool>> CreatePassword(CreatePasswordDTO input)
        {
            var result = await _ApiUrl.PostAsJsonAsync($"{BaseApiInfo.ApiAddress}api/CreatePassword", input);
            return JsonConvert.DeserializeObject<ApiResultDTO<bool>>(result.Content.ReadAsStringAsync().Result);
        }
        public async Task<ApiResultDTO<bool>> DeletePassword(PasswordListItemDTO input)
        {
            var result = await _ApiUrl.PostAsJsonAsync($"{BaseApiInfo.ApiAddress}api/DeletePassword", input);
            return JsonConvert.DeserializeObject<ApiResultDTO<bool>>(result.Content.ReadAsStringAsync().Result);
        }
    }
}
