using Microsoft.AspNetCore.Mvc;
using PolicySubmission.DatabaseEntity;
using PolicySubmission.Service;

namespace PolicySubmission.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : Controller
    {
        private readonly IRegistrationService _iRegistrationService;
        public RegistrationController(IRegistrationService registrationService)
        {
            _iRegistrationService = registrationService;
        }
        [HttpPost]
        public ActionResult<string> CreateMember ([FromBody] MemberRegistration member)
        {
            string result = _iRegistrationService.CreateMember(member);
            return Ok(new { _result = result });
        }
    }
}
