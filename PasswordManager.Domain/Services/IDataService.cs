using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.Domain.Models;

namespace PasswordManager.Domain.Services
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(int id);

        Task<T> Create(T entity);
        Task<T> AddRecord(Account account, Record record);
        Task<T> UpdateRecord(T entity, Record record);
        Task<T> DeleteRecord(T entity, Record record);
        Task<string> GetAESKey(int id);
        Task<string> GetAESIV(int id);
        Task<string> GetPassword(int id);

    }
}
