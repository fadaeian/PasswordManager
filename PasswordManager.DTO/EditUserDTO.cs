using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.DTO
{
	public class EditUserDTO:UserListItemDTO
	{
        public string Address { get; set; } = string.Empty;
        public DateTime RegisterDate { get; set; }
    }
}
