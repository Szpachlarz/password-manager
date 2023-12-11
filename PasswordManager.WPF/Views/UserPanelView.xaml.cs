using System.Windows.Controls;
using System.Windows.Input;

namespace PasswordManager.WPF.Views
{
    /// <summary>
    /// Interaction logic for UserPanelView.xaml
    /// </summary>
    public partial class UserPanelView : UserControl
    {
        public UserPanelView()
        {
            InitializeComponent();
        }
        
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Hand;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = null;
        }
    }
}
