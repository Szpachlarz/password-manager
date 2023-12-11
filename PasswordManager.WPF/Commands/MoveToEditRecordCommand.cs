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
using PasswordManager.WPF.Models;
using PasswordManager.WPF.State.Navigators;

namespace PasswordManager.WPF.Commands
{
    public class MoveToEditRecordCommand : AsyncCommandBase
    {
        private readonly IAccountStore _accountStore;
        private readonly IRenavigator _renavigator;
        private readonly UserPanelViewModel _userPanelViewModel;

        public MoveToEditRecordCommand(IAccountStore accountStore, IRenavigator renavigator, UserPanelViewModel userPanelViewModel)
        {
            _accountStore = accountStore;
            _renavigator = renavigator;
            _userPanelViewModel = userPanelViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var temp = parameter as UserRecord;
            _accountStore.SelectedRecord = temp;
            _renavigator.Renavigate();
            
        }

    }
}
