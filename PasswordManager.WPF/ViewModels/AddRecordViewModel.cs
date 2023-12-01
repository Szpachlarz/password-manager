using PasswordManager.WPF.Commands;
using PasswordManager.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PasswordManager.WPF.ViewModels
{
    public class AddRecordViewModel : ViewModelBase
    {
        public ICommand ViewUserPanelCommand { get; }
        public AddRecordViewModel(IRenavigator renavigator)
        {
            ViewUserPanelCommand = new RenavigateCommand(renavigator);
        }
    }
}
