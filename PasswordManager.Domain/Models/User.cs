using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Domain.Models
{
    public class User : DomainObject
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string AesKey { get; set; } 
        public string AesIV { get; set; }
    }
}
