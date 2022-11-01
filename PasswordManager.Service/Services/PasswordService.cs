using AutoMapper;
using Newtonsoft.Json;
using PasswordManager.Base.Helpers;
using PasswordManager.DTO;
using PasswordManager.Entity.Models;
using PasswordManager.Repository.Interfaces;
using PasswordManager.Service.Helper;
using PasswordManager.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Service.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly IPasswordRepository _passwordRepository;
        private readonly IMapper _mapper;

        public PasswordService(IMapper mapper, IPasswordRepository passwordRepository)
        {
            _passwordRepository = passwordRepository;
            _mapper = mapper;
        }

        public ApiResultDTO<List<PasswordListItemDTO>> GetAllPassword()
        {

            ApiResultDTO<List<PasswordListItemDTO>> output = new ApiResultDTO<List<PasswordListItemDTO>>();
            try
            {

                output.Data = _mapper.Map<List<PasswordListItemDTO>>(_passwordRepository.ReadAll());
                SeriLogHelper.SaveSuccessLog(output, "GetAllPassword", "All User Password");

            }
            catch (Exception e)
            {
                SeriLogHelper.SaveErrorLog(output, e, "GetAllPassword");
            }
            return output;

        }


        public ApiResultDTO<EditPasswordDTO> GetPasswordDetail(string id)
        {

            ApiResultDTO<EditPasswordDTO> output = new ApiResultDTO<EditPasswordDTO>();

            try
            {
                output.Data = _mapper.Map<EditPasswordDTO>(_passwordRepository.ReadById(int.Parse(EncryptHelper.Decrypt(id.ToString()))));
                SeriLogHelper.SaveSuccessLog(output, "GetPasswordDetail", JsonConvert.SerializeObject(output.Data));
            }
            catch (Exception e)
            {
                SeriLogHelper.SaveErrorLog(output, e, "GetPasswordDetail");
            }

            return output;
        }

        public ApiResultDTO<bool> UpdatePassword(EditPasswordDTO input)
        {
            ApiResultDTO<bool> output = new ApiResultDTO<bool>();
            try
            {
                _passwordRepository.Update(_mapper.Map<Passwords>(input));
                SeriLogHelper.SaveSuccessLog(output, "UpdatePassword",
                    JsonConvert.SerializeObject(output.Data));
            }
            catch (Exception e)
            {
                SeriLogHelper.SaveErrorLog(output, e, "UpdatePassword");
            }
            return output;

        }
        public ApiResultDTO<bool> CreatePassword(CreatePasswordDTO input)
        {
            ApiResultDTO<bool> output = new ApiResultDTO<bool>();
            try
            {

                if (!_passwordRepository.PasswordExist(_mapper.Map<Passwords>(input)))
                {

                    _passwordRepository.Create(_mapper.Map<Passwords>(input));
                    SeriLogHelper.SaveSuccessLog(output, "CreatePassword", String.Format("Password:{0}", input.Name));
                }
                else
                {
                    SeriLogHelper.SaveFailLog(output, "CreatePassword", "Password Name Exist");
                }
            }
            catch (Exception e)
            {
                SeriLogHelper.SaveErrorLog(output, e, "CreatePassword");
            }
            return output;

        }
        public ApiResultDTO<bool> DeletePassword(PasswordListItemDTO input)
        {
            ApiResultDTO<bool> output = new ApiResultDTO<bool>();
            try
            {
                _passwordRepository.Delete(_mapper.Map<Passwords>(input));
                SeriLogHelper.SaveSuccessLog(output, "DeletePassword", String.Format("Name:{0}", input.Name));
            }
            catch (Exception e)
            {
                SeriLogHelper.SaveErrorLog(output, e, "DeletePassword");
            }
            return output;
        }
    }
}
