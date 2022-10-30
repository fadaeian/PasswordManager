using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PasswordManager.Api.Controllers
{
    //[Authorize]
    [Route("api/[action]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {

        protected T _service;
        public BaseController(T service)
        {
            _service = service;
        }
    }
}
