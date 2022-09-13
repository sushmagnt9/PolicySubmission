using Microsoft.AspNetCore.Mvc;
using PolicySubmission.DatabaseEntity;
using PolicySubmission.Service;

namespace PolicySubmission.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PolicyController
    {
        private readonly IPolicyService _iPolicyService;
        public PolicyController(IPolicyService policyService)
        {
            _iPolicyService = policyService;
        }
        [HttpPost]
        public ActionResult<string> CreatePolicy([FromBody] Policy policy)
        {
            string result = _iPolicyService.CreatePolicy(policy);
           return new JsonResult(result);
            //return Ok(new { _result = result });
            
        }
        [HttpPut("UpdatePolicy")]
        public ActionResult UpdatePolicy([FromBody] Policy policy)
        {

            string result = _iPolicyService.UpdatePolicy(policy);
            return new JsonResult(result);
        }
    }
}
