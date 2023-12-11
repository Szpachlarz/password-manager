using PasswordManager.Domain.Exceptions;
using PasswordManager.WPF.State.Authenticators;
using PasswordManager.WPF.State.Navigators;
using PasswordManager.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandyControl.Controls;

namespace PasswordManager.WPF.Commands
{
    public class LoginCommand : AsyncCommandBase
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;

        public LoginCommand(LoginViewModel loginViewModel, IAuthenticator authenticator, IRenavigator renavigator)
        {
            _loginViewModel = loginViewModel;
            _authenticator = authenticator;
            _renavigator = renavigator;

            _loginViewModel.PropertyChanged += LoginViewModel_PropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return _loginViewModel.CanLogin && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _loginViewModel.ErrorMessage = string.Empty;

            try
            {
                await _authenticator.Login(_loginViewModel.Username, _loginViewModel.Password);

                _renavigator.Renavigate();
            }
            catch (UserNotFoundException)
            {
                Growl.Warning("Podany użytownik nie istnieje!");
            }
            catch (InvalidPasswordException)
            {
                Growl.Warning("Podano błędne hasło!");
            }
            catch (Exception)
            {
                Growl.Warning("Błąd logowania!");
            }
        }

        private void LoginViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LoginViewModel.CanLogin))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
