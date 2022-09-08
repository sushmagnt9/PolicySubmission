using PolicySubmission.DatabaseEntity;

namespace PolicySubmission.Service
{
    public interface IRegistrationService
    {
        List<MemberRegistration> GetAllMembers();
        string CreateMember(MemberRegistration member);
       //List<MemberRegistration> SearchMember(MemberRegistration member);
        MemberRegistration GetMemberById(int userId);
    }
}