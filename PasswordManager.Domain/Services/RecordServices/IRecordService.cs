using PasswordManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Domain.Services.RecordServices
{
    public interface IRecordService
    {
        Task<IEnumerable<Record>> GetRecordsById(Account account);

        Task<Account> AddRecord(Account user, string title, string website, string username, string password, string description);

        Task<Account> UpdateRecord(int recordId, Account user, string title, string website, string username, string password, string description);

        Task<Account> DeleteRecord(int recordId, Account user);
    }
}
