﻿using PasswordManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.WPF.Models;

namespace PasswordManager.WPF.State.Accounts
{
    public class AccountStore : IAccountStore
    {
        private Account _currentUser;
        public UserRecord SelectedRecord { get; set; }

        public Account CurrentUser
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
