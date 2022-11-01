using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using PasswordManager.DTO;
using PasswordManager.Entity.Models;
using PasswordManager.Repository.Interfaces;
using PasswordManager.Service.Helper;
using PasswordManager.Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PasswordManager.Service.Services
{
    public class AuthService:IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public AuthService(IMapper mapper,IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ApiResultDTO<string>> Login(LoginDTO input) {
            ApiResultDTO<string> output = new ApiResultDTO<string>();

            try
            {
                
                var result =  _userRepository.FindUser(_mapper.Map<User>(input));
                if(result != null)
                {
                    SeriLogHelper.SaveSuccessLog(output,"Login",string.Format("UserName:{0}",input.UserName));
                    output.Data = CreateJWTToken(result.UserName);               
                }
                else
                {
                    SeriLogHelper.SaveFailLog(output, "Login", "Login Fail");
                }
            }
            catch (Exception e)
            {
                SeriLogHelper.SaveErrorLog(output, e, "Login");
            }

            return output;
        }

        public string CreateJWTToken(string userName)
        {
            try
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MF@daEiAnD#v#l0per"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    claims: new List<Claim>
                    {
                    new Claim("USERNAME", userName.ToString()),
                    },
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds);

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);
                return jwt;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return null;
        }
    }
}
