using Microsoft.AspNet.Identity;
using PasswordManager.Domain.Services.RecordServices;
using PasswordManager.WPF.Commands;
using PasswordManager.WPF.State.Accounts;
using PasswordManager.WPF.State.Authenticators;
using PasswordManager.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PasswordManager.WPF.ViewModels
{
    public class UserPanelViewModel : ViewModelBase
    {
        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);

        public ICommand LoadRecordsCommand { get; }
        public ICommand ViewAddRecordCommand { get; }
        public ICommand UserLogout { get; }
        public UserPanelViewModel(IRenavigator addRecordRenavigator, IRecordService recordService, IAccountStore accountStore, IAuthenticator authenticator, IRenavigator loginRenavigator)
        {
            ViewAddRecordCommand = new RenavigateCommand(addRecordRenavigator);
            LoadRecordsCommand = new LoadRecordsCommand(recordService, accountStore);
            UserLogout = new LogoutCommand(this, authenticator, loginRenavigator);
        }

    }
}
