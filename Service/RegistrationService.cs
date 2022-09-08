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
                MemberRegistration m = new MemberRegistration();
                m.UserName = member.UserName;
                m.FirstName = member.FirstName;
                m.LastName = member.LastName;
                m.Email = member.Email;
                m.Dob = member.Dob;
                m.Address = member.Address;
                m.State = member.State;
                m.Email = member.Email;
                _policySubmissionContext.MemberRegistrations.Add(m);
                _policySubmissionContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return $"member Operation failed {ex.Message}";
            }
            return "Member Details saved sucessfully";

        }
        //public List<MemberRegistration> SearchMember(MemberRegistration member)
        //{
        //    return _policySubmissionContext.MemberRegistrations.Where(x => (x.FirstName == member.FirstName && x.LastName == member.LastName)).ToList();
        //}

        public object GetMemberById(int MemberId)
        {
            var user = _policySubmissionContext.MemberRegistrations.Where(b => b.MemberId == MemberId).FirstOrDefault();
            var x = from m in _policySubmissionContext.MemberRegistrations join p in _policySubmissionContext.Policies
                    on m.MemberId equals p.MemberId into ts  from t in ts.DefaultIfEmpty() 
                    where m.MemberId == MemberId
                    select new{MemberId =m.MemberId,PolicyId= t.MemberId == null ? 0 : (t.MemberId),UserName = m.UserName,FirstName = m.FirstName,
                    LastName = m.LastName,
                        //policyId= t.PolicyId == null ? 0 : (t.PolicyId),
                        policyStatus = (t.PolicyStatus == null || t.PolicyStatus == "" ) ? "No Policy Found" : t.PolicyStatus, policyType = t.PolicyType , 
                        premiumAmount = t.PremiumAmount
                    };
            return x;
        }
    }
}
