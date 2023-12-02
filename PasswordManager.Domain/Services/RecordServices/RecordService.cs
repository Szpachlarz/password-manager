using PasswordManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Domain.Services.RecordServices
{
    public class RecordService : IRecordService
    {
        private readonly IDataService<Account> _dataService;

        public RecordService(IDataService<Account> dataService)
        {
            _dataService = dataService;
        }

        public async Task<Account> AddRecord(Account account, string title, string website, string email, string password, string description)
        {
            Record newRecord = new Record()
            {
                Account = account,
                Title = title,
                Website = website,
                Email = email,
                Password = password,
                Description = description,
                Created = DateTime.Now
            };

            account.Records.Add(newRecord);
            await _dataService.Update(account.Id, account);
            return account;
        }

        public async Task<Account> DeleteRecord(Account account, string title, string website, string email, string password, string description)
        {
            throw new NotImplementedException();
        }

        public async Task<Account> EditRecord(Account account, string title, string website, string email, string password, string description)
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<Record>> GetRecordsById(Guid userId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
