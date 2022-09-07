using PolicySubmission.DatabaseEntity;

namespace PolicySubmission.Service
{
    public class RegistrationService : IRegistrationService
    {
        private readonly PolicySubmissionContext _policySubmissionContext;
        public RegistrationService(PolicySubmissionContext policySubmissionContext)
        {
            _policySubmissionContext = policySubmissionContext;
        }
        public string CreateMember(MemberRegistration member)
        {
            try
            {
                _policySubmissionContext.MemberRegistrations.Add(member);
                _policySubmissionContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return $"User Operation failed {ex.Message}";
            }
            return "User Details saved sucessfully";

        }
    }
}
