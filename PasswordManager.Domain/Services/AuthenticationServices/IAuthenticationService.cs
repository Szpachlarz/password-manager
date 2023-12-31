﻿using PasswordManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Domain.Services.AuthenticationServices
{
    public enum RegistrationResult
    {
        Success,
        PasswordsDoNotMatch,
        UsernameAlreadyExists,
        UsernameTooShort,
        UsernameTooLong,
        PasswordTooShort,
        PasswordTooLong
    }

    public interface IAuthenticationService
    {
        Task<RegistrationResult> Register(string username, string password, string confirmPassword);

        Task<Account> Login(string username, string password);
    }
}
