using Microsoft.EntityFrameworkCore.Migrations.Operations;
using PasswordManager.Domain.Models;
using PasswordManager.Domain.Services.RecordServices;
using PasswordManager.WPF.State.Accounts;
using PasswordManager.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using HandyControl.Controls;
using NETCore.Encrypt;
using PasswordManager.WPF.Models;
using PasswordManager.WPF.State.Navigators;

namespace PasswordManager.WPF.Commands
{
    public class EditRecordCommand : AsyncCommandBase
    {
        private readonly IRecordService _recordService;
        private readonly IAccountStore _accountStore;
        private readonly IRenavigator _renavigator;
        private readonly EditRecordViewModel _editRecordViewModel;

        public EditRecordCommand(IRecordService recordService, IAccountStore accountStore, IRenavigator renavigator, EditRecordViewModel editRecordViewModel)
        {
            _recordService = recordService;
            _accountStore = accountStore;
            _renavigator = renavigator;
            _editRecordViewModel = editRecordViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var aesKey = await _recordService.GetAESKey(_accountStore.CurrentUser);
            var iv = await _recordService.GetAESIV(_editRecordViewModel.Id);
            Record record = new();
            record.Id = _editRecordViewModel.Id;
            record.Title = _editRecordViewModel.Title;
            record.Website = _editRecordViewModel.Website;
            record.Username = _editRecordViewModel.Username;
            record.Password = EncryptProvider.AESEncrypt(_editRecordViewModel.Password, aesKey, iv);
            record.Description = _editRecordViewModel.Description;
            record.Created = DateTime.Now;
            await _recordService.UpdateRecord(record.Id, _accountStore.CurrentUser, record.Title, record.Website,
                record.Username, record.Password, record.Description, record.Created);
            Growl.Success("Pomyślnie edytowano rekord!");
            _renavigator.Renavigate();
        }
    }
}
