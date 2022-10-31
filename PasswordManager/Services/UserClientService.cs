﻿using Newtonsoft.Json;
using PasswordManager.Base;
using PasswordManager.DTO;
using PasswordManager.Interfaces;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

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

        public async Task<ApiResultDTO<EditUserDTO>> GetUserDetail(string id) {
            var result = await _ApiUrl.GetFromJsonAsync<ApiResultDTO<EditUserDTO>>($"https://localhost:7197/api/UsersDetail?id={id}");
            return result;
        }

        public async Task<ApiResultDTO<bool>> UpdateUser(EditUserDTO input)
        {
            var result = await _ApiUrl.PostAsJsonAsync($"https://localhost:7197/api/UpdateUser", input);
            return JsonConvert.DeserializeObject<ApiResultDTO<bool>>(result.Content.ReadAsStringAsync().Result);
        }
        public async Task<ApiResultDTO<bool>> CreateUser(CreateUserDTO input)
        {
            var result = await _ApiUrl.PostAsJsonAsync($"https://localhost:7197/api/CreateUser", input);
            return JsonConvert.DeserializeObject<ApiResultDTO<bool>>(result.Content.ReadAsStringAsync().Result);
        }

        public async Task<ApiResultDTO<bool>> DeleteUser(UserListItemDTO input)
        {
            var result = await _ApiUrl.PostAsJsonAsync($"https://localhost:7197/api/DeleteUser", input);
            return JsonConvert.DeserializeObject<ApiResultDTO<bool>>(result.Content.ReadAsStringAsync().Result);
        }



    }
}
