﻿using Microsoft.AspNet.Identity;
using PasswordManager.Domain.Exceptions;
using PasswordManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Domain.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountService _accountService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(IAccountService accountService, IPasswordHasher passwordHasher)
        {
            _accountService = accountService;
            _passwordHasher = passwordHasher;
        }

        public async Task<UserAccount> Login(string username, string password)
        {
            UserAccount storedAccount = await _accountService.GetByUsername(username);

            if (storedAccount == null)
            {
                throw new UserNotFoundException(username);
            }

            PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(storedAccount.PasswordHash, password);

            if (passwordResult != PasswordVerificationResult.Success)
            {
                throw new InvalidPasswordException(username, password);
            }

            return storedAccount;
        }

        public async Task<RegistrationResult> Register(string username, string password, string confirmPassword)
        {
            RegistrationResult result = RegistrationResult.Success;

            if (password != confirmPassword)
            {
                result = RegistrationResult.PasswordsDoNotMatch;
            }

            UserAccount usernameAccount = await _accountService.GetByUsername(username);
            if (usernameAccount != null)
            {
                result = RegistrationResult.UsernameAlreadyExists;
            }

            if (result == RegistrationResult.Success)
            {
                string hashedPassword = _passwordHasher.HashPassword(password);

                UserAccount user = new UserAccount()
                {
                    Username = username,
                    PasswordHash = hashedPassword,
                };

                await _accountService.Create(user);
            }

            return result;
        }
    }
}
