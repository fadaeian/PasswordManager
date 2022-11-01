using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.DTO
{
    public class PasswordListItemDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SiteURL { get; set; }
        public string UserName { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
