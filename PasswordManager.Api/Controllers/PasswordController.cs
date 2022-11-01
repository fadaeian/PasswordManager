using Microsoft.AspNetCore.Mvc;
using PasswordManager.DTO;
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


        [HttpGet]
        [ActionName("PasswordDetail")]
        public async Task<IActionResult> PasswordDetail(string id)
        {
            return Ok(_service.GetPasswordDetail(id));
        }


        [HttpPost]
        [ActionName("CreatePassword")]
        public async Task<IActionResult> CreatePassword(CreatePasswordDTO input)
        {
            return Ok(_service.CreatePassword(input));

        }

        [HttpPost]
        [ActionName("DeletePassword")]
        public async Task<IActionResult> DeletePassword(PasswordListItemDTO input)
        {
            return Ok(_service.DeletePassword(input));
        }

        [HttpPost]
        [ActionName("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword(EditPasswordDTO input)
        {
            return Ok(_service.UpdatePassword(input));

        }
    }
}
