using PasswordManager.Domain.Models;
using PasswordManager.Domain.Services.AuthenticationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.WPF.State.Authenticators
{
    public interface IAuthenticator
    {
        UserAccount CurrentUser { get; }
        bool IsLoggedIn { get; }

        event Action StateChanged;

        Task<RegistrationResult> Register(string username, string password, string confirmPassword);

        Task Login(string username, string password);

        void Logout();
    }
}
