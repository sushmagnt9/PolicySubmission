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
                Policy p = new Policy();
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
    }
}
