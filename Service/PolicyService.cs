using PolicySubmission.DatabaseEntity;

namespace PolicySubmission.Service
{
    public class PolicyService : IPolicyService
    {
        private readonly PolicySubmissionContext _policySubmissionContext;
        public PolicyService(PolicySubmissionContext policySubmissionContext)
        {
            _policySubmissionContext = policySubmissionContext;
        }
        public string CreatePolicy(Policy policy)
        {
            try
            {
                if(_policySubmissionContext.Policies.Where(h => h.PolicyType == policy.PolicyType && h.MemberId == policy.MemberId).Count()>0)
                {
                    return $"Policy already exists with MemberId:{policy.MemberId}";
                }
                Policy p = new Policy();
                p.PolicyId = policy.PolicyId;
                p.PolicyStatus = policy.PolicyStatus;
                p.PolicyType = policy.PolicyType;
                p.PolicyEffectiveDate = policy.PolicyEffectiveDate;
                p.PremiumAmount = policy.PremiumAmount;
                p.MemberId = policy.MemberId;
                _policySubmissionContext.Policies.Add(p);
                _policySubmissionContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return $"policy Operation failed {ex.Message}";
            }
            return "policy Details saved sucessfully";

        }
        public string UpdatePolicy(Policy policy)
        {
            try 
            { 
            var result = _policySubmissionContext.Policies.Where(x => x.MemberId == policy.MemberId).FirstOrDefault();
                //_policySubmissionContext.Policies.Where(x => x.MemberId == policy.MemberId).FirstOrDefault();
            string message = string.Empty;
             if(result != null)
             {
                //result.PolicyId = policy.PolicyId;
                result.PolicyStatus = policy.PolicyStatus;
                result.PolicyType = policy.PolicyType;
                result.PremiumAmount = policy.PremiumAmount;
                result.PolicyEffectiveDate = policy.PolicyEffectiveDate;
                result.MemberId = policy.MemberId;
                _policySubmissionContext.SaveChanges();
                return $"Policy is updated for PolicyId:{result.PolicyId}";
            }
            else
            {
                return "InValid input";
            }
          }
            catch(Exception ex)
            {
                return "Error occurred in Update";
            }
    //}
    //else
    //{
    //    message = "Invalid input";
    //}
    //return message;
}
    }
}
