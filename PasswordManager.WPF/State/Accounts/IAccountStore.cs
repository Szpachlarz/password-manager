using PasswordManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.WPF.Models;

namespace PasswordManager.WPF.State.Accounts
{
    public interface IAccountStore
    {
        public UserRecord SelectedRecord { get; set; }
        Account CurrentUser { get; set; }
        event Action StateChanged;
    }
}
