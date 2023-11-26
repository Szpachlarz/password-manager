using password_manager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace password_manager.Domain.Services.AuthenticationServices
{
    public enum RegistrationResult
    {
        Success,
        PasswordsDoNotMatch,
        UsernameAlreadyExists
    }

    public interface IAuthenticationService
    {
        Task<RegistrationResult> Register(string username, string password, string confirmPassword);

        Task<UserAccount> Login(string username, string password);

    }
}
