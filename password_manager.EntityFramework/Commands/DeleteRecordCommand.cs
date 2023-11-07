using password_manager.Domain.Commands;
using password_manager.Domain.Models;
using password_manager.EntityFramework.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace password_manager.EntityFramework.Commands
{
    public class DeleteRecordCommand : IDeleteRecordCommand
    {
        private readonly password_managerDbContextFactory _contextFactory;

        public DeleteRecordCommand(password_managerDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Guid id)
        {
            using (password_managerDbContext context = _contextFactory.Create())
            {
                RecordDto recordDto = new RecordDto()
                {
                    RecordId = id
                };

                context.Records.Remove(recordDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
