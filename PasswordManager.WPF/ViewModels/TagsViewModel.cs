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
    public class TagsViewModel : ViewModelBase
    {
        public ICommand ViewUserPanelCommand { get; }
        public TagsViewModel(IRenavigator renavigator)
        {
            ViewUserPanelCommand = new RenavigateCommand(renavigator);
        }
    }
}
