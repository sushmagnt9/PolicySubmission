using Microsoft.AspNetCore.Mvc;
using PolicySubmission.DatabaseEntity;
using PolicySubmission.Service;

namespace PolicySubmission.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController:Controller
    {
        private readonly IUserService _iUserService;
        public UserController(IUserService userService)
        {
            _iUserService = userService;
        }
        [HttpGet]
        public ActionResult GetAllUsers()
        {
            return Ok(_iUserService.GetAllUsers());
        }
        [HttpPost]
        public ActionResult<string> CreateUser([FromBody] User user)
        {
            string result = _iUserService.CreateUser(user);
            return Ok(new { _result = result });
        }
    }
}
