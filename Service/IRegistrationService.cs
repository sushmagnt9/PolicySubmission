using PolicySubmission.DatabaseEntity;

namespace PolicySubmission.Service
{
    public interface IRegistrationService
    {
        string CreateMember(MemberRegistration member);
    }
}