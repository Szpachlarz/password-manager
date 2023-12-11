using PasswordManager.Domain.Services.RecordServices;
using PasswordManager.WPF.Commands;
using PasswordManager.WPF.State.Accounts;
using PasswordManager.WPF.State.Authenticators;
using PasswordManager.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NETCore.Encrypt;
using PasswordManager.Domain.Models;

namespace PasswordManager.WPF.ViewModels
{
    public class EditRecordViewModel : ViewModelBase
    {
        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        
        private string _website;
        public string Website
        {
            get
            {
                return _website;
            }
            set
            {
                _website = value;
                OnPropertyChanged(nameof(Website));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private bool _isSubmitting;
        public bool IsSubmitting
        {
            get
            {
                return _isSubmitting;
            }
            set
            {
                _isSubmitting = value;
                OnPropertyChanged(nameof(IsSubmitting));
            }
        }

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
        public bool CanSubmit => !string.IsNullOrEmpty(Title) && !string.IsNullOrEmpty(Website) && !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password) /*&& Title.Length > 5 && Title.Length < 50 && Website.Length < 300 && Username.Length > 4 && Username.Length < 30 && Password.Length > 7 && Password.Length < 32*/;

        public ICommand SubmitCommand { get; set; }
        public ICommand ViewUserPanelCommand { get; set; }

        public EditRecordViewModel(IAccountStore accountStore, IRecordService recordService, IRenavigator userPanelRenavigator)
        {
            Initialize(accountStore, recordService, userPanelRenavigator);
        }
        
        private async void Initialize(IAccountStore accountStore, IRecordService recordService, IRenavigator userPanelRenavigator)
        {
            _id = accountStore.SelectedRecord.Id;
            _password = await FillPassword(recordService, accountStore);
            _username = accountStore.SelectedRecord.Username;
            _website = accountStore.SelectedRecord.Website;
            _title = accountStore.SelectedRecord.Title;
            _description = accountStore.SelectedRecord.Description;
            ViewUserPanelCommand = new RenavigateCommand(userPanelRenavigator);
            SubmitCommand = new EditRecordCommand(recordService, accountStore, userPanelRenavigator, this);
        }

        private async Task<string> FillPassword(IRecordService recordService, IAccountStore accountStore)
        {
            var aes = await recordService.GetAES(accountStore.CurrentUser);
            var password = await recordService.GetPasswordById(accountStore.SelectedRecord.Id);
            var passwordResult = EncryptProvider.AESDecrypt(password, aes.Item1, aes.Item2);
            return passwordResult;
        }
    }
}
