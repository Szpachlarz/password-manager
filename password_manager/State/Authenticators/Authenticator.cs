using password_manager.Domain.Models;
using password_manager.Domain.Services.AuthenticationServices;
using password_manager.WPF.State.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace password_manager.WPF.State.Authenticators
{
    public class Authenticator : IAuthenticator
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAccountStore _accountStore;

        public Authenticator(IAuthenticationService authenticationService, IAccountStore accountStore)
        {
            _authenticationService = authenticationService;
            _accountStore = accountStore;
        }
        public UserAccount CurrentUser
        {
            get
            {
                return _accountStore.CurrentUser;
            }
            private set
            {
                _accountStore.CurrentUser = value;
                StateChanged?.Invoke();
            }
        }

        public bool IsLoggedIn => CurrentUser != null;

        public event Action StateChanged;

        public async Task Login(string username, string password)
        {
            CurrentUser = await _authenticationService.Login(username, password);
        }

        public void Logout()
        {
            CurrentUser = null;
        }

        public async Task<RegistrationResult> Register(string username, string password, string confirmPassword)
        {
            return await _authenticationService.Register(username, password, confirmPassword);
        }
    }
}
