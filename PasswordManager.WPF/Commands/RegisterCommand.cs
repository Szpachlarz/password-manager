using PasswordManager.Domain.Services.AuthenticationServices;
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
    public class RegisterCommand : AsyncCommandBase
    {
        private readonly RegisterViewModel _registerViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _registerRenavigator;

        public RegisterCommand(RegisterViewModel registerViewModel, IAuthenticator authenticator, IRenavigator registerRenavigator)
        {
            _registerViewModel = registerViewModel;
            _authenticator = authenticator;
            _registerRenavigator = registerRenavigator;

            _registerViewModel.PropertyChanged += RegisterViewModel_PropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return _registerViewModel.CanRegister && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _registerViewModel.ErrorMessage = string.Empty;

            try
            {
                RegistrationResult registrationResult = await _authenticator.Register(
                       _registerViewModel.Username,
                       _registerViewModel.Password,
                       _registerViewModel.ConfirmPassword);

                switch (registrationResult)
                {
                    case RegistrationResult.Success:
                        _registerRenavigator.Renavigate();
                        Growl.Success("Pomyślnie zarejestrowano.");
                        break;
                    case RegistrationResult.PasswordsDoNotMatch:
                        Growl.Warning("Podane hasła nie są takie same.");
                        break;
                    case RegistrationResult.UsernameAlreadyExists:
                        Growl.Warning("Użytkownik o podanej nazwie już istnieje.");
                        break;
                    case RegistrationResult.UsernameTooShort:
                        Growl.Warning("Nazwa użytkownika jest zbyt krótka.");
                        break;
                    case RegistrationResult.UsernameTooLong:
                        Growl.Warning("Nazwa użytkownika jest zbyt długa.");
                        break;
                    case RegistrationResult.PasswordTooShort:
                        Growl.Warning("Hasło jest zbyt krótkie.");
                        break;
                    case RegistrationResult.PasswordTooLong:
                        Growl.Warning("Hasło jest zbyt długie.");
                        break;
                    default:
                        Growl.Warning("Błąd rejestracji.");
                        break;
                }
            }
            catch (Exception)
            {
                Growl.Error("Błąd rejestracji.");
            }
        }

        private void RegisterViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(RegisterViewModel.CanRegister))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
