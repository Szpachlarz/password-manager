using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace password_manager.Domain.Models
{
    public class UserAccount
    {
        public Guid Id { get; }
        public string Username { get; }
        public string Password { get; }
    }
}
