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
    public class UpdateRecordCommand : AsyncCommandBase
    {
        private readonly UpdateRecordViewModel _updateRecordViewModel;
        private readonly IRecordService _recordService;
        private readonly IAccountStore _accountStore;
        public UpdateRecordCommand(Record record, UpdateRecordViewModel updateRecordViewModel, IRecordService recordService, IAccountStore accountStore)
        {
            _updateRecordViewModel = updateRecordViewModel;
            _recordService = recordService;
            _accountStore = accountStore;

            //_addRecordViewModel.PropertyChanged += AddRecordViewModel_PropertyChanged;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            RecordFormViewModel recordFormViewModel = _updateRecordViewModel.RecordFormViewModel;

            recordFormViewModel.ErrorMessage = null;
            recordFormViewModel.IsSubmitting = true;

            //Record record = new Record(
            //    _updateRecordViewModel.RecordId,
            //    recordFormViewModel.Title,
            //    recordFormViewModel.Website,
            //    recordFormViewModel.Username,
            //    recordFormViewModel.Password,
            //    recordFormViewModel.Description);

            try
            {
                int id = _updateRecordViewModel.RecordId;
                string title = recordFormViewModel.Title;
                string website = recordFormViewModel.Website;
                string username = recordFormViewModel.Username;
                string password = recordFormViewModel.Password;
                string description = recordFormViewModel.Description;

                Account account = await _recordService.UpdateRecord(id, _accountStore.CurrentUser, title, website, username, password, description);

                _accountStore.CurrentUser = account;
            }
            catch (Exception)
            {
                _updateRecordViewModel.RecordFormViewModel.ErrorMessage = "Operacja nie powiodła się";
            }

            
        }
    }
}
