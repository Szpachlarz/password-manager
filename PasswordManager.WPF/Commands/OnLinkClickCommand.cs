using PasswordManager.Domain.Models;
using PasswordManager.Domain.Services.RecordServices;
using PasswordManager.WPF.State.Accounts;
using PasswordManager.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandyControl.Controls;
using PasswordManager.WPF.Models;

namespace PasswordManager.WPF.Commands
{
    public class OnLinkClickCommand : AsyncCommandBase
    {

        public OnLinkClickCommand()
        {
        }
        public override async Task ExecuteAsync(object parameter)
        {
            if (parameter is string url)
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true,
                        Verb = "open"
                    });
                }
                catch (Exception e)
                {
                    Growl.Error("Nie udało się otworzyć strony");
                }
                
            }
        }
    }
}
