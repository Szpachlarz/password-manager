﻿using Microsoft.EntityFrameworkCore.Migrations.Operations;
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

namespace PasswordManager.WPF.Commands
{
    public class AddRecordCommand : AsyncCommandBase
    {
        private readonly AddRecordViewModel _addRecordViewModel;
        private readonly IRecordService _recordService;
        private readonly IAccountStore _accountStore;

        public AddRecordCommand(AddRecordViewModel addRecordViewModel, IRecordService recordService, IAccountStore accountStore)
        {
            _addRecordViewModel = addRecordViewModel;
            _recordService = recordService;
            _accountStore = accountStore;

            //_addRecordViewModel.PropertyChanged += AddRecordViewModel_PropertyChanged;
        }

        //public override bool CanExecute(object parameter)
        //{
        //    return _addRecordViewModel.RecordFormViewModel.CanSubmit && base.CanExecute(parameter);
        //}

        public override async Task ExecuteAsync(object parameter)
        {
            //RecordFormViewModel recordFormViewModel = _addRecordViewModel.RecordFormViewModel;

            //recordFormViewModel.ErrorMessage = null;
            //recordFormViewModel.IsSubmitting = true;

            _addRecordViewModel.ErrorMessage = null;
            _addRecordViewModel.IsSubmitting = true;

            //Record record = new Record(
            //    _updateRecordViewModel.RecordId,
            //    recordFormViewModel.Title,
            //    recordFormViewModel.Website,
            //    recordFormViewModel.Username,
            //    recordFormViewModel.Password,
            //    recordFormViewModel.Description);
            var aesKeyGen = EncryptProvider.CreateAesKey();

            string title = _addRecordViewModel.Title;
            string website = _addRecordViewModel.Website;
            string username = _addRecordViewModel.Username;
            var aesKey = await _recordService.GetAESKey(_accountStore.CurrentUser);
            var aesIV = aesKeyGen.IV;
            string password = EncryptProvider.AESEncrypt(_addRecordViewModel.Password, aesKey, aesIV);
            string description = _addRecordViewModel.Description;
            try
            {
                Account account = await _recordService.AddRecord(_accountStore.CurrentUser, title, website, username, password, description, aesIV);

                _accountStore.CurrentUser = account;
                _addRecordViewModel.Title = string.Empty;
                _addRecordViewModel.Website = string.Empty;
                _addRecordViewModel.Username = string.Empty;
                _addRecordViewModel.Password = string.Empty;
                _addRecordViewModel.Description = string.Empty;
                Growl.Success("Pomyślnie dodano konto do bazdy danych!");
            }
            catch (Exception)
            {
                Growl.Error("Operacja nie powiodła się");
            }
            finally
            {
                _addRecordViewModel.IsSubmitting = false;
            }
        }

        //private void AddRecordViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    if (e.PropertyName == nameof(AddRecordViewModel.RecordFormViewModel.CanSubmit))
        //    {
        //        OnCanExecuteChanged();
        //    }
        //}
    }
}
