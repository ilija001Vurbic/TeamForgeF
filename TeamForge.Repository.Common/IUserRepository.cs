using System;
using System.Collections.Generic;
using TeamForge.Model;

namespace TeamForge.Repository.Common
{
    public interface IUserRepository
    {
        User GetUserById(Guid userId);
        IEnumerable<User> GetAllUsers();
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(Guid userId);
        User GetUserByUsername(string username); // New method for getting user by username
        bool VerifyPassword(string enteredPassword, string storedHash); // New method for verifying password
    }
}