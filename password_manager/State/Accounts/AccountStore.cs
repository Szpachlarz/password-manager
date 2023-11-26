using password_manager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace password_manager.WPF.State.Accounts
{
    public class AccountStore : IAccountStore
    {
        private UserAccount _currentUser;
        public UserAccount CurrentUser
        {
            get
            {
                return _currentUser;
            }
            set
            {
                _currentUser = value;
                StateChanged?.Invoke();
            }
        }

        public event Action StateChanged;
    }
}
