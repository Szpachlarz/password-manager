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

        public async Task<Account> AddRecord(Account account, string title, string website, string username, string password, string description, string AESIV)
        {
            Record newRecord = new Record()
            {
                Account = account,
                Title = title,
                Website = website,
                Username = username,
                Password = password,
                Description = description,
                Created = DateTime.Now,
                AES_IV = AESIV
            };

            account.Records.Add(newRecord);
            await _dataService.AddRecord(account, newRecord);
            return account;
        }

        public async Task<Account> DeleteRecord(int recordId, Account account)
        {
            Record deleteRecord = account.Records.FirstOrDefault(r => r.Id == recordId);

            if (deleteRecord != null)
            {
                await _dataService.DeleteRecord(account, deleteRecord);
            }

            return account;
        }

        public async Task<string> GetAESKey(Account user)
        {
            return await _dataService.GetAESKey(user.AccountHolder.Id);;
        }
        
        public async Task<string> GetAESIV(int id)
        {
            return await _dataService.GetAESIV(id);;
        }

        public async Task<Account> UpdateRecord(int recordId, Account account, string title, string website, string username, string password, string description, DateTime created)
        {
            Record updateRecord = account.Records.FirstOrDefault(r => r.Id == recordId);

            if (updateRecord != null)
            {
                updateRecord.Title = title;
                updateRecord.Website = website;
                updateRecord.Username = username;
                updateRecord.Password = password;
                updateRecord.Description = description;
                updateRecord.Created = created;
            }

            //account.Records.Add(updatedRecord);
            await _dataService.UpdateRecord(account, updateRecord);
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
