using AutoMapper;
using Microsoft.IdentityModel.Logging;
using Newtonsoft.Json;
using PasswordManager.Base.Helpers;
using PasswordManager.DTO;
using PasswordManager.Entity.Models;
using PasswordManager.Repository.Interfaces;
using PasswordManager.Repository.Repositories;
using PasswordManager.Service.Helper;
using PasswordManager.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Xml;

namespace PasswordManager.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public ApiResultDTO<List<UserListItemDTO>> GetAllUsers()
        {

            ApiResultDTO<List<UserListItemDTO>> output = new ApiResultDTO<List<UserListItemDTO>>();
            try
            {

                output.Data = _mapper.Map<List<UserListItemDTO>>(_userRepository.ReadAll());
                SeriLogHelper.SaveSuccessLog(output, "GetAllUsers", "All User List");

            }
            catch (Exception e)
            {
                SeriLogHelper.SaveErrorLog(output, e, "GetAllUsers");
            }
            return output;

        }


        public ApiResultDTO<EditUserDTO> GetUserDetail(string id)
        {

            ApiResultDTO<EditUserDTO> output = new ApiResultDTO<EditUserDTO>();

            try
            {
                output.Data = _mapper.Map<EditUserDTO>(_userRepository.ReadById(int.Parse(EncryptHelper.Decrypt(id.ToString()))));
                SeriLogHelper.SaveSuccessLog(output, "GetUserDetail", JsonConvert.SerializeObject(output.Data));
            }
            catch (Exception e)
            {
                SeriLogHelper.SaveErrorLog(output, e, "GetUserDetail");
            }

            return output;
        }

        public ApiResultDTO<bool> UpdateUser(EditUserDTO input)
        {
            ApiResultDTO<bool> output = new ApiResultDTO<bool>();
            try
            {
                _userRepository.Update(_mapper.Map<User>(input));
                SeriLogHelper.SaveSuccessLog(output, "UpdateUser",
                    JsonConvert.SerializeObject(output.Data));
            }
            catch (Exception e)
            {
                SeriLogHelper.SaveErrorLog(output, e, "UpdateUser");
            }
            return output;

        }
        public ApiResultDTO<bool> CreateUser(CreateUserDTO input)
        {
            ApiResultDTO<bool> output = new ApiResultDTO<bool>();
            try
            {

                if (!_userRepository.UserExist(_mapper.Map<User>(input)))
                {

                    _userRepository.Create(_mapper.Map<User>(input));
                    SeriLogHelper.SaveSuccessLog(output, "CreateUser", String.Format("UserName:{0}", input.UserName));
                }
                else
                {
                    SeriLogHelper.SaveFailLog(output, "CreateUser", "User Exist");
                }
            }
            catch (Exception e)
            {
                SeriLogHelper.SaveErrorLog(output, e, "UpdateUser");
            }
            return output;

        }
        public ApiResultDTO<bool> DeleteUser(UserListItemDTO input)
        {
            ApiResultDTO<bool> output = new ApiResultDTO<bool>();
            try
            {
                _userRepository.Delete(_mapper.Map<User>(input));
                SeriLogHelper.SaveSuccessLog(output, "DeleteUser", String.Format("UserName:{0}",input.UserName));
            }
            catch (Exception e)
            {
                SeriLogHelper.SaveErrorLog(output, e, "DeleteUser");
            }
            return output;
        }
    }
}
