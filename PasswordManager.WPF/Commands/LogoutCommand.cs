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

namespace PasswordManager.WPF.Commands
{
    public class LogoutCommand : AsyncCommandBase
    {
        private readonly UserPanelViewModel _userPanelViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;

        public LogoutCommand(UserPanelViewModel userPanelViewModel, IAuthenticator authenticator, IRenavigator renavigator)
        {
            _userPanelViewModel = userPanelViewModel;
            _authenticator = authenticator;
            _renavigator = renavigator;

            _userPanelViewModel.PropertyChanged += UserPanelViewModel_PropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            //return _userPanelViewModel.CanLogout && base.CanExecute(parameter);
            return base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _userPanelViewModel.ErrorMessage = string.Empty;

            try
            {
                _authenticator.Logout();
                _renavigator.Renavigate();
            }
            catch (Exception) 
            {
                _userPanelViewModel.ErrorMessage = "Logout failed.";
            }                
        }

        private void UserPanelViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //if (e.PropertyName == nameof(UserPanelViewModel.CanLogout))
            //{
            //    OnCanExecuteChanged();
            //}

            OnCanExecuteChanged();
        }

    }
}
