using PolicySubmission.DatabaseEntity;

namespace PolicySubmission.Service
{
    public interface IUserService
    {
        string CreateUser(User user);
        List<User> GetAllUsers();
    }
}