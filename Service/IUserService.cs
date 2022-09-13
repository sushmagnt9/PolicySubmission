using PolicySubmission.DatabaseEntity;

namespace PolicySubmission.Service
{
    public interface IUserService
    {
        string CreateUser(User user);
        User Login(User user);
        List<User> GetAllUsers();
    }
}