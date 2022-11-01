using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.DTO
{
    public class CreateUserDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }= string.Empty;
        public DateTime RegisterDate { get; set; }

    }
}
