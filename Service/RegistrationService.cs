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
        public List<MemberRegistration> GetAllMembers()
        {
            return _policySubmissionContext.MemberRegistrations.ToList();
        }
        public string CreateMember(MemberRegistration member)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(member.UserName) && !string.IsNullOrWhiteSpace(member.FirstName) && !string.IsNullOrWhiteSpace(member.LastName)
                    && !string.IsNullOrWhiteSpace(member.Email) && !string.IsNullOrWhiteSpace(member.State) && !string.IsNullOrWhiteSpace(member.Address) &&
                    !string.IsNullOrWhiteSpace(member.State))
                    {
                    MemberRegistration m = new MemberRegistration();
                    m.UserName = member.UserName;
                    m.FirstName = member.FirstName;
                    m.LastName = member.LastName;
                    m.Email = member.Email;
                    m.Dob = member.Dob;
                    m.Address = member.Address;
                    m.State = member.State;
                    _policySubmissionContext.MemberRegistrations.Add(m);
                    _policySubmissionContext.SaveChanges();
                    return "Member Details saved sucessfully";
                }
                return "invalid data";
            }
            catch (Exception ex)
            {
                return $"member Operation failed {ex.Message}";
            }
        
        }
        //public List<MemberRegistration> SearchMember(MemberRegistration member)
        //{
        //    return _policySubmissionContext.MemberRegistrations.Where(x => (x.FirstName == member.FirstName && x.LastName == member.LastName)).ToList();
        //}

        public object GetMemberById(int MemberId,string FirstName,string LastName,string policyStatus)
        {
            if (policyStatus == "" || policyStatus == null)
            {
                policyStatus = "something";
            }
            var user = _policySubmissionContext.MemberRegistrations.Where(b => b.MemberId == MemberId).FirstOrDefault();
            var x = from m in _policySubmissionContext.MemberRegistrations join p in _policySubmissionContext.Policies
                    on m.MemberId equals p.MemberId into ts  from t in ts.DefaultIfEmpty() 
                    where m.MemberId == MemberId || (m.FirstName == FirstName && m.LastName == LastName) || t.PolicyStatus == policyStatus                    
                    select new{MemberId =m.MemberId,PolicyId= t.PolicyId == null ? 0 : (t.PolicyId),UserName = m.UserName,FirstName = m.FirstName,
                    LastName = m.LastName,
                        //policyId= t.PolicyId == null ? 0 : (t.PolicyId),
                        policyStatus = (t.PolicyStatus == null || t.PolicyStatus == "" ) ? "No Policy Found" : t.PolicyStatus, policyType = t.PolicyType , 
                        PremiumAmount =t.PremiumAmount == null ? "0" :(t.PremiumAmount),
                        PolicyEffectiveDate = t.PolicyEffectiveDate == null ? DateTime.Now : t.PolicyEffectiveDate
                    };
            if (x.Count() > 0)
            {
                return x;
            }
            else
            {
                return "No record found";
            }
        }
    }
}
