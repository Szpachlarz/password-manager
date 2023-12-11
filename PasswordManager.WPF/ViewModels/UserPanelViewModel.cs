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
using System.Windows.Media;
using HandyControl.Tools;
using PasswordManager.Domain.Models;
using PasswordManager.WPF.Models;

namespace PasswordManager.WPF.ViewModels
{
    public class UserPanelViewModel : ViewModelBase
    {
        private string _errorMessage;
        private List<UserRecord> _recordsList;
        private Brush _backgroundColor = Brushes.Aqua;
        public Brush BackgroundColor
        {
            get
            {
                return _backgroundColor;
            }
            set
            {
                _backgroundColor = value;
                OnPropertyChanged(nameof(BackgroundColor));
            }
        }
        
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

        private string _username;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public List<UserRecord> RecordsList
        {
            get
            {
                return _recordsList;
            }
            set
            {
                _recordsList = value;
                OnPropertyChanged(nameof(RecordsList));
            }
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);

        public ICommand LoadRecordsCommand { get; }
        public ICommand ViewAddRecordCommand { get; }
        public ICommand DeleteRecordCommand { get; }
        public ICommand MoveToEditRecordCommand { get; }
        public ICommand OnLinkClickCommand { get; }
        public ICommand CopyPasswordToClipboardCommand { get; }
        public ICommand UserLogout { get; }
        public UserPanelViewModel(IRenavigator addRecordRenavigator, IRenavigator editRecordRenavigator, IRecordService recordService, IAccountStore accountStore, IAuthenticator authenticator, IRenavigator loginRenavigator)
        {
            Username = accountStore.CurrentUser.AccountHolder.Username;
            ViewAddRecordCommand = new RenavigateCommand(addRecordRenavigator);
            LoadRecordsCommand = new LoadRecordsCommand(recordService, accountStore, this);
            MoveToEditRecordCommand = new MoveToEditRecordCommand(accountStore, editRecordRenavigator, this);
            DeleteRecordCommand = new DeleteRecordCommand(recordService, accountStore, this);
            OnLinkClickCommand = new OnLinkClickCommand();
            UserLogout = new LogoutCommand(this, authenticator, loginRenavigator);
            CopyPasswordToClipboardCommand = new CopyPasswordToClipboardCommand(recordService, accountStore, this);
            LoadRecordsCommand.Execute(null);
        }

    }
}
