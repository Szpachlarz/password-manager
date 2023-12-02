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
        //Task<IEnumerable<UserAccount>> GetRecordsById(Guid userId);

        Task<Account> AddRecord(Account user, string title, string website, string email, string password, string description);

        Task<Account> EditRecord(Account user, string title, string website, string email, string password, string description);

        Task<Account> DeleteRecord(Account user, string title, string website, string email, string password, string description);
    }
}
