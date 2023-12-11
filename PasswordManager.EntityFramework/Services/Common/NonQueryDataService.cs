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
        public async Task<T> AddRecord(Account account,Record record)
        {
            using (PasswordManagerDbContext context = _contextFactory.CreateDbContext())
            {
                var userAcc = context.Accounts.Include(x => x.Records).SingleOrDefault(x => x.Id == account.Id);

                if (userAcc != null)
                {
                    userAcc.Records.Add(record);

                    await context.SaveChangesAsync();
                }
                
                return null;
            }
        }
        public async Task<T> DeleteRecord(Account account, Record record)
        {
            using (PasswordManagerDbContext context = _contextFactory.CreateDbContext())
            {
                var userRecord = context.Records.Include(x => x.Account).FirstOrDefault(x=> x.Id == record.Id);

                if (userRecord == null)
                {
                    return null;
                }

                context.Remove(userRecord);
                
                await context.SaveChangesAsync();

                return null;
            }
        }
        public async Task<T> UpdateRecord(Account account, Record record)
        {
            using (PasswordManagerDbContext context = _contextFactory.CreateDbContext())
            {
                
                var userRecord = context.Records.Include(x => x.Account).FirstOrDefault(x=> x.Id == record.Id);

                if (userRecord == null)
                {
                    return null;
                }
                
                userRecord.Title = record.Title;
                userRecord.Website = record.Website;
                userRecord.Username = record.Username;
                userRecord.Password = record.Password;
                userRecord.Description = record.Description;
                userRecord.Created = record.Created;

                context.Update(userRecord);

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
        
        public async Task<string> GetAESKey(int id)
        {
            using (PasswordManagerDbContext context = _contextFactory.CreateDbContext())
            {
                var key = context.Users.FirstOrDefault(x=> x.Id == id).AesKey;

                
                return key;
            }
        }
        
        public async Task<string> GetAESIV(int id)
        {
            using (PasswordManagerDbContext context = _contextFactory.CreateDbContext())
            {
                var iv = context.Records.FirstOrDefault(x => x.Id == id).AES_IV;

                
                return iv;
            }
        }
    }
}
