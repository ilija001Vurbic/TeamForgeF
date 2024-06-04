using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamForge.Model.Common
{
    public interface IUser
    {
        Guid Id { get; set; }
        string Username { get; set; }
        string PasswordHash { get; set; }
        UserRole Role { get; set; }
    }
}
