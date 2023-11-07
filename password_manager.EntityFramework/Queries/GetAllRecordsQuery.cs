using Microsoft.EntityFrameworkCore;
using password_manager.Domain.Models;
using password_manager.Domain.Queries;
using password_manager.EntityFramework.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace password_manager.EntityFramework.Queries
{
    public class GetAllRecordsQuery : IGetAllRecordsQuery
    {
        private readonly password_managerDbContextFactory _contextFactory;

        public GetAllRecordsQuery(password_managerDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Record>> Execute()
        {
            using (password_managerDbContext context = _contextFactory.Create())
            {
                IEnumerable<RecordDto> recordDtos = await context.Records.ToListAsync();

                return recordDtos.Select(y => new Record (y.RecordId, y.Title, y.Website, y.Email, y.Password, y.Description, y.Created));
            }
        }
    }
}
