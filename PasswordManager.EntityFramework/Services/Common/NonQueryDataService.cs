using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PasswordManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.EntityFramework.Services.Common
{
    public class NonQueryDataService<T> where T : DomainObject
    {
        private readonly PasswordManagerDbContextFactory _contextFactory;
        public NonQueryDataService(PasswordManagerDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using (PasswordManagerDbContext context = _contextFactory.CreateDbContext())
            {
                EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();

                return createdResult.Entity;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using (PasswordManagerDbContext context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;

                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();

                return entity;
            }
        }
        
        public async Task<T> UpdateRecord(int id, ICollection<Record> records)
        {
            using (PasswordManagerDbContext context = _contextFactory.CreateDbContext())
            {
                
                var oldUser = await context.Accounts.Include(u => u.Records).FirstOrDefaultAsync(u => u.Id == id);

                if (oldUser == null)
                {
                    return null;
                }

                var oldUserRecords = oldUser.Records; 
                var valuesToAdd = records.Except(oldUserRecords).ToList();
                var valuesToRemove = oldUserRecords.Except(records).ToList();
                foreach (var valueToAdd in valuesToAdd)
                {
                    Record record = new Record()
                    {
                        Account = oldUser,
                        Title = valueToAdd.Title,
                        Website = valueToAdd.Website,
                        Username = valueToAdd.Username,
                        Password = valueToAdd.Password,
                        Description = valueToAdd.Description,
                        Created = DateTime.Now
                    };
                    context.Add(record);
                }

                foreach (var valueToRemove in valuesToRemove)
                {
                    var entityToRemove = context.Records.FirstOrDefault(e => e.Id == valueToRemove.Id);
                    if (entityToRemove != null)
                    {
                        context.Records.Remove(entityToRemove);
                    }
                }

                await context.SaveChangesAsync();

                return null;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (PasswordManagerDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }
        }
        
        public async Task<string> GetPassword(int id)
        {
            using (PasswordManagerDbContext context = _contextFactory.CreateDbContext())
            {
                var password = context.Records.FirstOrDefault(x => x.Id == id).Password;
                await context.SaveChangesAsync();

                return password;
            }
        }
        
        public Task<Tuple<string, string>> GetAES(int id)
        {
            using (PasswordManagerDbContext context = _contextFactory.CreateDbContext())
            {
                var key = context.Users.FirstOrDefault(x=> x.Id == id).AesKey;
                var iv = context.Users.FirstOrDefault(x=> x.Id == id).AesIV;
                var aes = new Tuple<string, string>(key, iv);
                
                return Task.FromResult(aes);
            }
        }
    }
}
