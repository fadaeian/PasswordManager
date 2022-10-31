using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Base;
using PasswordManager.DTO;
using PasswordManager.Service.Interfaces;

namespace PasswordManager.Api.Controllers
{
    [AllowAnonymous]
    public class AuthController : BaseController<IAuthService>
    {

        public AuthController(IAuthService authService) :base(authService)
        { }

        [AllowAnonymous]
        [HttpPost]
        [ActionName("Login")]
        public async Task<IActionResult> Login(LoginDTO input)
        {
            return Ok(await _service.Login(input));
        }
    }
}
