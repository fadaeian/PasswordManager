using PasswordManager.Entity.Managers;
using PasswordManager.Entity.Models;
using PasswordManager.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Repository.Repositories
{
    public class PasswordRepository: IPasswordRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public PasswordRepository(ApplicationDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }


        public List<Passwords> ReadAll()
        {

            return _dbContext.Passwords.ToList();

        }

        public Passwords ReadById(int id)
        {
            return _dbContext.Passwords.Find(id);
        }

        public Passwords Update(Passwords entity)
        {
            if (entity != null)
            {
                _dbContext.Passwords.Update(entity);
                _dbContext.SaveChanges();
            }
            return entity;
        }

        public Passwords Delete(Passwords entity)
        {
            _dbContext.Passwords.Remove(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public Passwords Create(Passwords entity)
        {
            _dbContext.Passwords.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public bool PasswordExist(Passwords entity)
        {
            return _dbContext.Passwords.
                Where(x => x.Name == entity.Password)
                .SingleOrDefault() != null;
        }
    }
}
