using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Base;
using PasswordManager.Service.Interfaces;

namespace PasswordManager.Api.Controllers
{
    [AllowAnonymous]
    public class AuthController : BaseController<IAuthService>
    {

        public AuthController(IAuthService authService) :base(authService)
        { }

        [AllowAnonymous]
        [HttpGet]
        [ActionName("GetToken")]
        public async Task<IActionResult> GetToken()
        {
            return Ok(_service.CreateJWTToken("Administrator", BaseApiInfo.AuthKey));
        }
    }
}
