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
    public class UserPanelViewModel : ViewModelBase
    {
        public ICommand ViewRegisterCommand { get; }
        public UserPanelViewModel(IRenavigator renavigator)
        {
            ViewRegisterCommand = new RenavigateCommand(renavigator);
        }

    }
}
