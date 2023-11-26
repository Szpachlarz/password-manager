using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Domain.Models
{
    public class UserAccount : DomainObject
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<Record> Records { get; } = new List<Record>();
    }
}
