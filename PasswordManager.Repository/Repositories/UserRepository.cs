using Microsoft.EntityFrameworkCore;
using PasswordManager.Entity.Managers;
using PasswordManager.Entity.Models;
using PasswordManager.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }


        public List<User> ReadAll()
        {

            return _dbContext.User.ToList();

        }

        public User ReadById(int id) {
            return _dbContext.User.Find(id);
        }

        public User Update(User entity) {
            if (entity != null)
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            return entity;
        }

        public User Delete(User entity)
        {
            _dbContext.User.Remove(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public User Create(User entity)
        {
            return entity;
        }

        public User FindUser(User entity)
        {
            return _dbContext.User.
                Where(c => c.Password == entity.Password &&
                (c.UserName == entity.UserName)).FirstOrDefault();
        }
    }
}
