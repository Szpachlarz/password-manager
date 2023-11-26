using password_manager.ViewModels;
using password_manager.WPF.Commands;
using password_manager.WPF.State.Authenticators;
using password_manager.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace password_manager.WPF.ViewModels
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
