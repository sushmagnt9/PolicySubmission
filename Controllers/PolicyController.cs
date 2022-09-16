using Microsoft.AspNetCore.Mvc;
using PolicySubmission.DatabaseEntity;
using PolicySubmission.Service;

namespace PolicySubmission.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PolicyController: ControllerBase
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
           //return new JsonResult(result);
            return Ok(new { result = result });
            
        }
        string result = string.Empty;
        [HttpPut("UpdatePolicy")]
        public ActionResult<string> UpdatePolicy([FromBody] Policy policy)
        {

            //string result = _iPolicyService.UpdatePolicy(policy);
            //return new JsonResult(result);
            try
            {
                result = _iPolicyService.UpdatePolicy(policy);

            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return Ok(new
            {
                Result = result.ToString()
            }); ;
        }
    }
}
