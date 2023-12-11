using System.Threading.Tasks;
using System.Windows;
using HandyControl.Controls;
using HandyControl.Tools.Command;
using NETCore.Encrypt;
using PasswordManager.Domain.Models;
using PasswordManager.Domain.Services.RecordServices;
using PasswordManager.WPF.Models;
using PasswordManager.WPF.State.Accounts;
using PasswordManager.WPF.ViewModels;

namespace PasswordManager.WPF.Commands;

public class CopyPasswordToClipboardCommand : AsyncCommandBase
{
    private readonly IRecordService _recordService;
    private readonly IAccountStore _accountStore;
    private readonly UserPanelViewModel _userPanelViewModel;

    public CopyPasswordToClipboardCommand(IRecordService recordService, IAccountStore accountStore, UserPanelViewModel userPanelViewModel)
    {
        _recordService = recordService;
        _accountStore = accountStore;
        _userPanelViewModel = userPanelViewModel;
    }

    public override async Task ExecuteAsync(object parameter)
    {
        var key = await _recordService.GetAESKey(_accountStore.CurrentUser);
        var record = parameter as UserRecord;
        var iv = await _recordService.GetAESIV(record.Id);
        var password = await _recordService.GetPasswordById(record.Id);
        Clipboard.SetText(EncryptProvider.AESDecrypt(password, key, iv));
        Growl.Success("Skopiowano hasło do schowka!");
    }
}