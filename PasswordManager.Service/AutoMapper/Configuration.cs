using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Service.AutoMapper
{
    public class Configuration
    {
        MapperConfiguration config = new(cfg =>
        {
            cfg.AddProfile<UserMapper>();
        });
    }
}
