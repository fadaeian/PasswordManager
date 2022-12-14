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
                _dbContext.User.Attach(entity);
                _dbContext.Entry(entity).Property(x => x.Email).IsModified = true;
                _dbContext.Entry(entity).Property(x => x.Address).IsModified = true;
                _dbContext.Entry(entity).Property(x => x.FirstName).IsModified = true;
                _dbContext.Entry(entity).Property(x => x.LastName).IsModified = true;
                _dbContext.Entry(entity).Property(x => x.RegisterDate).IsModified = true;
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
            _dbContext.User.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public User FindUser(User entity)
        {
            return _dbContext.User.
                Where(c => c.Password == entity.Password &&
                (c.UserName == entity.UserName)).FirstOrDefault();
        }

        public bool UserExist(User entity)
        {
            return _dbContext.User.
                Where(x => x.UserName == entity.UserName || x.Email.ToLower() == entity.Email.ToLower())
                .SingleOrDefault() != null;
        }
    }
}
