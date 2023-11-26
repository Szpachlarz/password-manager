using password_manager.Domain.Models;
using password_manager.Domain.Services.AuthenticationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace password_manager.WPF.State.Authenticators
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
