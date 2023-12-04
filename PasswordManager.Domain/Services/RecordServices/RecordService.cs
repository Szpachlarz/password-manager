using PasswordManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PasswordManager.Domain.Services.RecordServices
{
    public class RecordService : IRecordService
    {
        private readonly IDataService<Account> _dataService;

        public RecordService(IDataService<Account> dataService)
        {
            _dataService = dataService;
        }

        public async Task<Account> AddRecord(Account account, string title, string website, string username, string password, string description)
        {
            Record newRecord = new Record()
            {
                Account = account,
                Title = title,
                Website = website,
                Username = username,
                Password = password,
                Description = description,
                Created = DateTime.Now
            };

            account.Records.Add(newRecord);
            await _dataService.Update(account.Id, account);
            return account;
        }

        public async Task<Account> DeleteRecord(int recordId, Account account)
        {
            Record deleteRecord = account.Records.FirstOrDefault(r => r.Id == recordId);

            if (deleteRecord != null)
            {
                account.Records.Remove(deleteRecord);
                await _dataService.Update(account.Id, account);
            }

            return account;
        }

        public async Task<Account> UpdateRecord(int recordId, Account account, string title, string website, string username, string password, string description)
        {
            Record updateRecord = account.Records.FirstOrDefault(r => r.Id == recordId);

            if (updateRecord != null)
            {
                updateRecord.Title = title;
                updateRecord.Website = website;
                updateRecord.Username = username;
                updateRecord.Password = password;
                updateRecord.Description = description;
            }

            //account.Records.Add(updatedRecord);
            await _dataService.Update(account.Id, account);
            return account;
        }

        public async Task<IEnumerable<Record>> GetRecordsById(Account account)
        {

            Account userAccount = await _dataService.Get(account.Id);

            if (userAccount != null)
            {
                return userAccount.Records;
            }

            return Enumerable.Empty<Record>();
        }
    }
}
