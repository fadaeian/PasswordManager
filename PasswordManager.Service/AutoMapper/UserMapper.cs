using AutoMapper;
using PasswordManager.Base.Helpers;
using PasswordManager.DTO;
using PasswordManager.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Service.AutoMapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserListItemDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => EncryptHelper.Encrypt(src.UserId.ToString())));
        }
    }
}
