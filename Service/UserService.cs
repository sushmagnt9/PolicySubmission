using PolicySubmission.DatabaseEntity;

namespace PolicySubmission.Service
{
    public class UserService : IUserService
    {
        private readonly PolicySubmissionContext _policySubmissionContext;
        public UserService(PolicySubmissionContext policySubmissionContext)
        {
            _policySubmissionContext = policySubmissionContext;
        }
        public List<User> GetAllUsers()
        {
            return _policySubmissionContext.Users.ToList();
        }

        public string CreateUser(User user)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(user.UserName) || !string.IsNullOrWhiteSpace(user.Password))
                {
                    _policySubmissionContext.Users.Add(user);
                    _policySubmissionContext.SaveChanges();
                    return "User Details saved sucessfully";
                }
                return "Details invalid";
            }
            catch (Exception ex)
            {
                return $"User Operation failed {ex.Message}";
            }
           

        }
    }
}
