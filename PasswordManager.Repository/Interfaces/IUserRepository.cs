using PasswordManager.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Repository.Interfaces
{
    public interface IUserRepository
    {
        List<User> ReadAll();
        User ReadById(int id);
        User Update(User entity);
        User Delete(User entity);

    }
}
