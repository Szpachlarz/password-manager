using password_manager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace password_manager.WPF.State.Accounts
{
    public interface IAccountStore
    {
        UserAccount CurrentUser { get; set; }
        event Action StateChanged;
    }
}
