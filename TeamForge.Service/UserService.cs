using TeamForge.Model;
using TeamForge.Repository.Common;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;

    public UserService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public User GetUserById(Guid userId)
    {
        return userRepository.GetUserById(userId);
    }

    public User GetUserByUsername(string username)
    {
        return userRepository.GetUserByUsername(username);
    }

    public IEnumerable<User> GetAllUsers()
    {
        return userRepository.GetAllUsers();
    }

    public void AddUser(User user)
    {
        userRepository.AddUser(user);
    }

    public bool VerifyPassword(string enteredPassword, string storedHash)
    {
        return userRepository.VerifyPassword(enteredPassword, storedHash);
    }
}