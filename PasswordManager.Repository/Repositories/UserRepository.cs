﻿using PasswordManager.Entity.Managers;
using PasswordManager.Entity.Models;
using PasswordManager.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Repository.Repositories
{
    public class UserRepository:IUserRepository
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


    }
}