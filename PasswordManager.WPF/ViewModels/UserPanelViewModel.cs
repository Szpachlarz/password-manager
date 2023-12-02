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
        public ICommand ViewAddRecordCommand { get; }
        public ICommand ViewTagsCommand { get; }
        public UserPanelViewModel(IRenavigator renavigator)
        {
            ViewAddRecordCommand = new RenavigateCommand(renavigator);
            ViewTagsCommand = new RenavigateCommand(renavigator);
        }

    }
}
