using PolicySubmission.DatabaseEntity;

namespace PolicySubmission.Service
{
    public interface IPolicyService
    {
        string CreatePolicy(Policy policy);

        string UpdatePolicy(Policy policies);
    }
}