using PasswordManager.Domain.Models;
using PasswordManager.WPF.State.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.WPF.State.Assets
{
    public class RecordStore
    {
        private readonly IAccountStore _accountStore;

        public IEnumerable<Record> Records => _accountStore.CurrentUser?.Records ?? new List<Record>();

        public event Action StateChanged;

        public RecordStore(IAccountStore accountStore)
        {
            _accountStore = accountStore;

            _accountStore.StateChanged += OnStateChanged;
        }

        private void OnStateChanged()
        {
            StateChanged?.Invoke();
        }
    }
}
