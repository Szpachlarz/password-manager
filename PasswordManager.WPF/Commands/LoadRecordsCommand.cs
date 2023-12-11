using PasswordManager.Domain.Models;
using PasswordManager.Domain.Services.RecordServices;
using PasswordManager.WPF.State.Accounts;
using PasswordManager.WPF.State.Assets;
using PasswordManager.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using PasswordManager.WPF.Models;

namespace PasswordManager.WPF.Commands
{
    public class LoadRecordsCommand : AsyncCommandBase
    {
        private readonly IRecordService _recordService;
        private readonly IAccountStore _accountStore;
        private readonly UserPanelViewModel _userPanelViewModel;

        public LoadRecordsCommand(IRecordService recordService, IAccountStore accountStore, UserPanelViewModel userPanelViewModel)
        {
            _recordService = recordService;
            _accountStore = accountStore;
            _userPanelViewModel = userPanelViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            Account currentUser = _accountStore.CurrentUser;
            
            try
            {
                var temp = await _recordService.GetRecordsById(currentUser);
                List<UserRecord> userRecords = new();
                foreach (var record in temp)
                {
                    var isUrlValid = IsUrlValid(record.Website);
                    userRecords.Add(new UserRecord()
                    {
                        Account = record.Account,
                        Created = record.Created,
                        Description = record.Description,
                        Id = record.Id,
                        Password = record.Password,
                        Title = record.Title,
                        Username = record.Username,
                        Website = record.Website,
                        HasUrl = isUrlValid,
                        ForegroundColor = isUrlValid ? Brushes.Blue : Brushes.Black,
                        TextDecoration = isUrlValid ? TextDecorations.Underline : null
                    });
                }
                _userPanelViewModel.RecordsList = userRecords;
            }
            catch (Exception)
            {
                //_userPanelViewModel.ErrorMessage = "Nie udało się załadować.";
            }

        }
        
        private bool IsUrlValid(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri result) && (result.Scheme == Uri.UriSchemeHttp || result.Scheme == Uri.UriSchemeHttps);
        }
    }
}
