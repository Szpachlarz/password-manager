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

namespace PasswordManager.WPF.Commands
{
    public class LoadRecordsCommand : AsyncCommandBase
    {
        private readonly IRecordService _recordService;
        private readonly IAccountStore _accountStore;

        public LoadRecordsCommand(IRecordService recordService, IAccountStore accountStore)
        {
            _recordService = recordService;
            _accountStore = accountStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            Account currentUser = _accountStore.CurrentUser;
            try
            {
                await _recordService.GetRecordsById(currentUser);
            }
            catch (Exception)
            {
                //_userPanelViewModel.ErrorMessage = "Nie udało się załadować.";
            }

        }
    }
}
