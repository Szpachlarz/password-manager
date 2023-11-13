using password_manager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace password_manager.Domain.Services
{
    public interface IAccountService : IDataService<UserAccount>
    {
        Task<UserAccount> GetByUsername(string username);
    }
}
