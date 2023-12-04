using PasswordManager.Domain.Models;
using PasswordManager.Domain.Services.RecordServices;
using PasswordManager.WPF.Commands;
using PasswordManager.WPF.State.Accounts;
using PasswordManager.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PasswordManager.WPF.ViewModels
{
    public class UpdateRecordViewModel : ViewModelBase
    {
        public int RecordId { get; }
        public RecordFormViewModel RecordFormViewModel { get; }
        public ICommand ViewUserPanelCommand { get; }
        public ICommand SubmitCommand { get; set; }

        public UpdateRecordViewModel(Record record, IAccountStore accountStore, IRecordService recordService, IRenavigator userPanelRenavigator)
        {
            RecordId = record.Id;
            ViewUserPanelCommand = new RenavigateCommand(userPanelRenavigator);
            SubmitCommand = new UpdateRecordCommand(record, this, recordService, accountStore);
            RecordFormViewModel = new RecordFormViewModel(SubmitCommand, ViewUserPanelCommand)
            {
                Title = record.Title,
                Website = record.Website,
                Username = record.Username,
                Password = record.Password,
                Description = record.Description,
            };
        }
    }
}
