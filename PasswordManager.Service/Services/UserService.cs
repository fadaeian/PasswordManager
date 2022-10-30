using AutoMapper;
using PasswordManager.DTO;
using PasswordManager.Entity.Models;
using PasswordManager.Repository.Interfaces;
using PasswordManager.Repository.Repositories;
using PasswordManager.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PasswordManager.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IMapper mapper,IUserRepository userRepository)
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
                output.Success = true;  

            } catch (Exception e) {
                output.Success = false;
            }
            return output;

        }
    }
}
