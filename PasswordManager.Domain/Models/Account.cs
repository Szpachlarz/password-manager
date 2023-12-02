using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Domain.Models
{
    public class Account : DomainObject
    {
        public User AccountHolder { get; set; }
        public ICollection<Record> Records { get; set; }
    }
}
