using Microsoft.EntityFrameworkCore;
using password_manager.Domain.Models;
using password_manager.Domain.Services;
using password_manager.EntityFramework.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace password_manager.EntityFramework.Services
{
    public class AccountDataService : IAccountService
    {
        private readonly password_managerDbContextFactory _contextFactory;
        private readonly NonQueryDataService<UserAccount> _nonQueryDataService;

        public AccountDataService(password_managerDbContextFactory contextFactory)
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
            using (password_managerDbContext context = _contextFactory.CreateDbContext())
            {
                UserAccount entity = await context.UserAccounts
                    .Include(a => a.Records)
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<UserAccount>> GetAll()
        {
            using (password_managerDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<UserAccount> entities = await context.UserAccounts
                    .Include(a => a.Records)
                    .ToListAsync();
                return entities;
            }
        }

        public async Task<UserAccount> GetByUsername(string username)
        {
            using (password_managerDbContext context = _contextFactory.CreateDbContext())
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
