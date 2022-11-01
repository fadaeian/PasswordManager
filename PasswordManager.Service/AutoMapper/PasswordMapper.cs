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
            CreateMap<Passwords, EditPasswordDTO>()
                       .ForMember(dest => dest.Id, opt => opt.MapFrom(src => EncryptHelper.Encrypt(src.PasswordId.ToString())))
                       .ForMember(dest => dest.Password, opt => opt.MapFrom(src => EncryptHelper.Decrypt(src.Password.ToString())));
            CreateMap<PasswordListItemDTO, Passwords>()
                .ForMember(dest => dest.PasswordId, opt => opt.MapFrom(src => EncryptHelper.Decrypt(src.Id.ToString())));
            CreateMap<EditPasswordDTO, Passwords>()
                       .ForMember(dest => dest.PasswordId, opt => opt.MapFrom(src => EncryptHelper.Decrypt(src.Id.ToString())))
                       .ForMember(dest => dest.Password, opt => opt.MapFrom(src => EncryptHelper.Encrypt(src.Password.ToString())))
                       .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom( src => DateTime.Now.ToString()));
            CreateMap<CreatePasswordDTO, Passwords>()
                       .ForMember(dest => dest.PasswordId, opt => opt.MapFrom(src => EncryptHelper.Decrypt(src.Id.ToString())))
                       .ForMember(dest => dest.Password, opt => opt.MapFrom(src => EncryptHelper.Encrypt(src.Password.ToString())));
        }
    }
}
