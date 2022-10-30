using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.DTO
{
    public class ApiResultDTO<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
    }
}
