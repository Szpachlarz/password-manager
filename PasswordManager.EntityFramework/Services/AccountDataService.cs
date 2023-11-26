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
        private readonly NonQueryDataService<UserAccount> _nonQueryDataService;

        public AccountDataService(PasswordManagerDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<UserAccount>(contextFactory);
        }
        public async Task<UserAccount> Create(UserAccount entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<UserAccount> Get(int id)
        {
            using (PasswordManagerDbContext context = _contextFactory.CreateDbContext())
            {
                UserAccount entity = await context.UserAccounts
                    .Include(a => a.Records)
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<UserAccount>> GetAll()
        {
            using (PasswordManagerDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<UserAccount> entities = await context.UserAccounts
                    .Include(a => a.Records)
                    .ToListAsync();
                return entities;
            }
        }

        public async Task<UserAccount> GetByUsername(string username)
        {
            using (PasswordManagerDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.UserAccounts
                    .Include(a => a.Records)
                    .FirstOrDefaultAsync(a => a.Username == username);
            }
        }

        public async Task<UserAccount> Update(int id, UserAccount entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}
