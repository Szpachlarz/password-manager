using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PasswordManager.WPF.Models;
using PasswordManager.WPF.ViewModels;

namespace PasswordManager.WPF.Components
{
    /// <summary>
    /// Interaction logic for UserPanelViewTable.xaml
    /// </summary>
    public partial class UserPanelViewTable : UserControl
    {
        private UserPanelViewModel ViewModel => (UserPanelViewModel)DataContext;
        public UserPanelViewTable()
        {
            InitializeComponent();
        }
        
        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is not FrameworkElement element) return;
            if (element.DataContext is not UserRecord record) return;
            if(record.HasUrl)
                Mouse.OverrideCursor = Cursors.Hand;
        }

        private void TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = null;
        }
        
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Hand;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = null; 
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is UserPanelViewModel viewModel)
            {
                if(sender is not FrameworkElement element) return;
                if(element.DataContext is not UserRecord record) return;
                if(!record.HasUrl) return;
                if (String.IsNullOrEmpty(record.Website)) return;
                viewModel.OnLinkClickCommand.Execute(record.Website);
            }
        }
    }
}
