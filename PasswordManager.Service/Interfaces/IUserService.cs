﻿using PasswordManager.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Service.Interfaces
{
    public interface IUserService
    {
        List<UserListItemDTO> GetAllUsers();
    }
}
