using PasswordManager.Repository.Interfaces;
using PasswordManager.Service.DTOs;
using PasswordManager.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Service.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<UserListItemDTO> GetAllUsers() {

          List<UserListItemDTO> ouput = new List<UserListItemDTO>();

          return ouput;

        }
    }
}
