using Microsoft.AspNetCore.Mvc;
using PasswordManager.Service.Interfaces;

namespace PasswordManager.Api.Controllers
{
    public class UserController : BaseController<IUserService>
    {

        public UserController(IUserService service) : base(service)
        {

        }


        [HttpGet]
        [ActionName("Users")]
        public async Task<IActionResult> GetAllUser()
        {
            var result = _service.GetAllUsers();
            return Ok();
        }
    }
}
