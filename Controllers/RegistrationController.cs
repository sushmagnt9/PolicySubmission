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
        [HttpGet]
        public ActionResult GetAllMembers()
        {
            return Ok(_iRegistrationService.GetAllMembers());
        }
        [HttpPost]
        public ActionResult<string> CreateMember([FromBody] MemberRegistration member)
        {
            string result = _iRegistrationService.CreateMember(member);
            return Ok(new { _result = result });
        }
        //public List<MemberRegistration> SearchMember([FromBody] MemberRegistration member)
        //{
        //    try
        //    {
        //        return _iRegistrationService.SearchMember(member);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new List<MemberRegistration>();
        //    }
        //}
        [HttpGet("GetMemberById")]
        public ActionResult<List<object>> GetMemberById(string userId)
        {
            string result = string.Empty;
            try
            {
                List<object> members = new List<object>();
                object member = _iRegistrationService.GetMemberById(Convert.ToInt32(userId));
                members.Add(member);
                if (member != null)
                            return Ok(members);
                        else
                            result = "user not found";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return Ok(result.ToList());
        }
    }
}
