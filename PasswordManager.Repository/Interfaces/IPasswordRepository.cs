using PasswordManager.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Repository.Interfaces
{
    public interface IPasswordRepository:IBaseRepository<Passwords,int>
    {
        bool PasswordExist(Passwords entity);
    }
}
