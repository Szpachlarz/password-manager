using Microsoft.EntityFrameworkCore;
using PasswordManager.Domain.Models;
using PasswordManager.Domain.Services;
using PasswordManager.EntityFramework.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.EntityFramework.Services
{
    public class AccountDataService : IAccountService
    {
        private readonly PasswordManagerDbContextFactory _contextFactory;
        private readonly NonQueryDataService<Account> _nonQueryDataService;

        public AccountDataService(PasswordManagerDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Account>(contextFactory);
        }
        public async Task<Account> Create(Account entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<Account> Get(int id)
        {
            using (PasswordManagerDbContext context = _contextFactory.CreateDbContext())
            {
                Account entity = await context.Accounts
                    .Include(a => a.AccountHolder)
                    .Include(a => a.Records)
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            using (PasswordManagerDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Account> entities = await context.Accounts
                    .Include(a => a.AccountHolder)
                    .Include(a => a.Records)
                    .ToListAsync();
                return entities;
            }
        }

        public async Task<Account> GetByUsername(string username)
        {
            using (PasswordManagerDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Accounts
                    .Include(a => a.AccountHolder)
                    .Include(a => a.Records)
                    .FirstOrDefaultAsync(a => a.AccountHolder.Username == username);
            }
        }

        public async Task<Account> GetById(int id)
        {
            using (PasswordManagerDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Accounts
                    .Include(a => a.AccountHolder)
                    .Include(a => a.Records)
                    .FirstOrDefaultAsync(a => a.AccountHolder.Id == id);
            }
        }

        public async Task<Account> Update(int id, Account entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
        
        public async Task<Account> UpdateRecord(int id, Account entity)
        {
            return await _nonQueryDataService.UpdateRecord(id, entity.Records);
        }

        public async Task<Tuple<string, string>> GetAES(int id)
        {
            return await _nonQueryDataService.GetAES(id);
        }

        public async Task<string> GetPassword(int id)
        {
            return await _nonQueryDataService.GetPassword(id);
        }
    }
}
