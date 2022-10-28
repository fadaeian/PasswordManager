using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Repository.Interfaces
{
    public interface IBaseRepository<T, K>
    {
        List<T> ReadAll();
        T ReadById(K id);
        T create(T entity);
        T update(T entity);
        T delete(T entity);
    }
}
