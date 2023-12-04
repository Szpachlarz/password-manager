using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Domain.Models
{
    public class Record : DomainObject
    {
        public Account Account { get; set; }
        public string Title { get; set; }
        public string Website { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        //public Guid UserId { get; set; }
        
    }
}
