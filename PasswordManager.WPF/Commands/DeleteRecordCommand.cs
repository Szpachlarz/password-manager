using PasswordManager.Domain.Models;
using PasswordManager.Domain.Services.RecordServices;
using PasswordManager.WPF.State.Accounts;
using PasswordManager.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandyControl.Controls;
using PasswordManager.WPF.Models;

namespace PasswordManager.WPF.Commands
{
    public class DeleteRecordCommand : AsyncCommandBase
    {
        private readonly RecordListingItemViewModel _recordListingViewModel;
        private readonly IRecordService _recordService;
        private readonly IAccountStore _accountStore;
        private readonly UserPanelViewModel _userPanelViewModel;

        public DeleteRecordCommand(IRecordService recordService, IAccountStore accountStore, RecordListingItemViewModel recordListingViewModel)
        {
            _recordListingViewModel = recordListingViewModel;
            _recordService = recordService;
            _accountStore = accountStore;

            //_addRecordViewModel.PropertyChanged += AddRecordViewModel_PropertyChanged;
        }
        
        public DeleteRecordCommand(IRecordService recordService, IAccountStore accountStore, UserPanelViewModel userPanelViewModel)
        {
            _recordService = recordService;
            _accountStore = accountStore;
            _userPanelViewModel = userPanelViewModel;

            //_addRecordViewModel.PropertyChanged += AddRecordViewModel_PropertyChanged;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            if (_recordListingViewModel != null)
            {
                Record record = _recordListingViewModel.Record;
                await _recordService.DeleteRecord(record.Id, _accountStore.CurrentUser);
            }
            else
            {
                if (parameter is UserRecord record)
                {
                    _accountStore.CurrentUser = await _recordService.DeleteRecord(record.Id, _accountStore.CurrentUser);
                    _userPanelViewModel.LoadRecordsCommand.Execute(null);
                    Growl.Success("Pomyślnie usunięto rekord");
                }
                else
                {
                    Growl.Error("Nieznany błąd");
                }
            }
        }
    }
}
