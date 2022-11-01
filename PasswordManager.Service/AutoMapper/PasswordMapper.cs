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
    public class PasswordMapper : Profile
    {
        public PasswordMapper()
        {
            CreateMap<Passwords, PasswordListItemDTO>()
                       .ForMember(dest => dest.Id, opt => opt.MapFrom(src => EncryptHelper.Encrypt(src.PasswordId.ToString())));
            CreateMap<PasswordListItemDTO, Passwords>()
                .ForMember(dest => dest.PasswordId, opt => opt.MapFrom(src => EncryptHelper.Decrypt(src.Id.ToString())));
            CreateMap<EditPasswordDTO, Passwords>()
                       .ForMember(dest => dest.PasswordId, opt => opt.MapFrom(src => EncryptHelper.Decrypt(src.Id.ToString())));
            CreateMap<CreatePasswordDTO, Passwords>()
                       .ForMember(dest => dest.PasswordId, opt => opt.MapFrom(src => EncryptHelper.Decrypt(src.Id.ToString())));
        }
    }
}
