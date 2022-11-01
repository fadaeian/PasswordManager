using Newtonsoft.Json;
using PasswordManager.Base;
using PasswordManager.Base.Helpers;
using PasswordManager.DTO;
using PasswordManager.Interfaces;
using System.Net.Http.Json;

namespace PasswordManager.Services
{
    public class LoginClientService:ILoginClientService
    {
        private readonly HttpClient _ApiUrl;
        public LoginClientService(HttpClient apiUrl)
        {
            _ApiUrl = apiUrl;
        }

        public async Task<ApiResultDTO<string>> Login(LoginDTO input) 
        {
            
            var result = await _ApiUrl.PostAsJsonAsync($"{BaseApiInfo.ApiAddress}api/Login", input);
            return JsonConvert.DeserializeObject<ApiResultDTO<string>>(result.Content.ReadAsStringAsync().Result);

        }


    }
}
