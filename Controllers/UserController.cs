using Microsoft.AspNetCore.Mvc;

namespace PolicySubmission.Controllers
{
    public class UserController
    {
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
