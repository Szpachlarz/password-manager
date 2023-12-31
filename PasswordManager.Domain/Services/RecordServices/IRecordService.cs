﻿using PasswordManager.Domain.Models;
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
        Task<string> GetPasswordById(int id);

        Task<Account> AddRecord(Account user, string title, string website, string username, string password, string description, string AESIV);

        Task<Account> UpdateRecord(int recordId, Account user, string title, string website, string username, string password, string description, DateTime created);

        Task<Account> DeleteRecord(int recordId, Account user);
        Task<string> GetAESKey(Account user);
        Task<string> GetAESIV(int id);
    }
}
