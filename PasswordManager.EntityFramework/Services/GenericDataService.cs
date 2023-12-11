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
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        private readonly PasswordManagerDbContextFactory _contextFactory;
        private readonly NonQueryDataService<T> _nonQueryDataService;
        public GenericDataService(PasswordManagerDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<T>(contextFactory);
        }

        public async Task<T> Create(T entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<T> Get(int id)
        {
            using (PasswordManagerDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (PasswordManagerDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();
                return entities;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }

        public Task<T> UpdateRecord(int id, T entity)
        {
            throw new NotImplementedException();
        }

        public Task<Tuple<string, string>> GetAES(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPassword(int id)
        {
            throw new NotImplementedException();
        }
    }
}
