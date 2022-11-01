using Microsoft.AspNetCore.Mvc;
using PasswordManager.Repository.Interfaces;
using PasswordManager.Service.Interfaces;

namespace PasswordManager.Api.Controllers
{
    public class PasswordController : BaseController<IPasswordService>
    {

        public PasswordController(IPasswordService service) : base(service)
        {

        }

        [HttpGet]
        [ActionName("Passwords")]
        public async Task<IActionResult> GetAllPassword()
        {
            return Ok(_service.GetAllPassword());
        }
    }
}
