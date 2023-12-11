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
        var aes = await _recordService.GetAES(_accountStore.CurrentUser);
        var record = parameter as UserRecord;
        var password = await _recordService.GetPasswordById(record.Id);
        Clipboard.SetText(EncryptProvider.AESDecrypt(password, aes.Item1, aes.Item2));
        Growl.Success("Skopiowano hasło do schowka!");
    }
}