﻿using PasswordManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.WPF.State.Accounts
{
    public interface IAccountStore
    {
        UserAccount CurrentUser { get; set; }
        event Action StateChanged;
    }
}
