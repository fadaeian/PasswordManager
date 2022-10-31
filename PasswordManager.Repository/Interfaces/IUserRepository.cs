using PasswordManager.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Repository.Interfaces
{
    public interface IUserRepository:IBaseRepository<User,int>
    {
        User FindUser(User entity);
    }
}
