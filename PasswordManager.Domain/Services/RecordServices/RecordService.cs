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

        public async Task<string> GetPasswordById(int id)
        {
            var password = await _dataService.GetPassword(id);
            return password;
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
                await _dataService.UpdateRecord(account.Id, account);
            }

            return account;
        }

        public async Task<Tuple<string, string>> GetAES(Account user)
        {
            var aes = await _dataService.GetAES(user.Id);
            return aes;
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
                return userAccount.Records.Select(r=> new Record()
                {
                    Id = r.Id,
                    Title = r.Title,
                    Website = r.Website,
                    Username = r.Username,
                    Password = String.Empty,
                    Description = r.Description,
                    Created = r.Created
                });
            }

            return Enumerable.Empty<Record>();
        }
    }
}
