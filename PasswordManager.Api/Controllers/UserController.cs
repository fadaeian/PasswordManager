using Microsoft.AspNetCore.Mvc;
using PasswordManager.DTO;
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
            return Ok(_service.GetAllUsers());
        }


        [HttpGet]
        [ActionName("UsersDetail")]
        public async Task<IActionResult> GetUserDetail(string id)
        {
            return Ok(_service.GetUserDetail(id));
        }


        [HttpPost]
        [ActionName("UpdateUser")]
        public async Task<IActionResult> UpdateUser(EditUserDTO input)
        {
            return Ok(_service.UpdateUser(input));

        }

        [HttpPost]
        [ActionName("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserDTO input)
        {
            return Ok(_service.CreateUser(input));

        }

        [HttpPost]
        [ActionName("DeleteUser")]
        public async Task<IActionResult> DeleteUser(UserListItemDTO input)
        {
            return Ok(_service.DeleteUser(input));
        }
        
    }
}
