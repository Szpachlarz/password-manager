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

namespace PasswordManager.WPF.ViewModels
{
    public class AddRecordViewModel : ViewModelBase
    {
        //public RecordFormViewModel RecordFormViewModel { get; }

        ////public ICommand ViewUserPanelCommand { get; }
        ////public ICommand SubmitCommand { get; set; }
        //public AddRecordViewModel(IAccountStore accountStore, IRecordService recordService, IRenavigator userPanelRenavigator)
        //{
        //    ICommand ViewUserPanelCommand = new RenavigateCommand(userPanelRenavigator);
        //    ICommand SubmitCommand = new AddRecordCommand(this, recordService, accountStore);
        //    RecordFormViewModel = new RecordFormViewModel(SubmitCommand, ViewUserPanelCommand);
        //}

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

        private bool _isNumber;
        public bool IsNumber
        {
            get
            {
                return _isNumber;
            }
            set
            {
                _isNumber = value;
                OnPropertyChanged(nameof(IsNumber));
            }
        }

        private bool _isSpecial;
        public bool IsSpecial
        {
            get
            {
                return _isSpecial;
            }
            set
            {
                _isSpecial = value;
                OnPropertyChanged(nameof(IsSpecial));
            }
        }

        private int _requiredLength = 8;
        public int RequiredLength
        {
            get
            {
                return _requiredLength;
            }
            set
            {
                _requiredLength = value;
                OnPropertyChanged(nameof(RequiredLength));
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

        public ICommand SubmitCommand { get; }
        public ICommand ViewUserPanelCommand { get; }
        public ICommand GeneratePasswdCommand { get; }

        public AddRecordViewModel(IAccountStore accountStore, IRecordService recordService, IRenavigator userPanelRenavigator)
        {
            //SubmitCommand = submitCommand;
            //ViewUserPanelCommand = cancelCommand;
            ViewUserPanelCommand = new RenavigateCommand(userPanelRenavigator);
            SubmitCommand = new AddRecordCommand(this, recordService, accountStore);
            GeneratePasswdCommand = new GeneratePasswordCommand(this);
        }
    }
}
