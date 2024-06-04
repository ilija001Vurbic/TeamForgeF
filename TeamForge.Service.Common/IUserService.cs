using TeamForge.Model;

public interface IUserService
{
    User GetUserById(Guid userId);
    User GetUserByUsername(string username);
    IEnumerable<User> GetAllUsers();
    void AddUser(User user);
    bool VerifyPassword(string enteredPassword, string storedHash);
}
