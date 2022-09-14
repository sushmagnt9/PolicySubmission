using PolicySubmission.DatabaseEntity;

namespace PolicySubmission.Service
{
    public interface IRegistrationService
    {
        List<MemberRegistration> GetAllMembers();
        string CreateMember(MemberRegistration member);
       //List<MemberRegistration> SearchMember(MemberRegistration member);
        object GetMemberById(int userId,string FirstName,string LastName,string policyStatus,int policyId);
    }
}