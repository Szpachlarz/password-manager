using PasswordManager.Domain.Models;
using PasswordManager.Domain.Services.RecordServices;
using PasswordManager.WPF.State.Accounts;
using PasswordManager.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.WPF.Commands
{
    public class DeleteRecordCommand : AsyncCommandBase
    {
        private readonly RecordListingItemViewModel _recordListingViewModel;
        private readonly IRecordService _recordService;
        private readonly IAccountStore _accountStore;

        public DeleteRecordCommand(IRecordService recordService, IAccountStore accountStore, RecordListingItemViewModel recordListingViewModel)
        {
            _recordListingViewModel = recordListingViewModel;
            _recordService = recordService;
            _accountStore = accountStore;

            //_addRecordViewModel.PropertyChanged += AddRecordViewModel_PropertyChanged;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            Record record = _recordListingViewModel.Record;
            await _recordService.DeleteRecord(record.Id, _accountStore.CurrentUser);
        }
    }
}
