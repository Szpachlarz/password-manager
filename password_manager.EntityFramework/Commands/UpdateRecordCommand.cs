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
    public class UpdateRecordCommand : IUpdateRecordCommand
    {
        private readonly password_managerDbContextFactory _contextFactory;

        public UpdateRecordCommand(password_managerDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Record record)
        {
            using (password_managerDbContext context = _contextFactory.Create())
            {
                RecordDto recordDto = new RecordDto()
                {
                    RecordId = record.RecordId,
                    Title = record.Title,
                    Website = record.Website,
                    Email = record.Email,
                    Password = record.Password,
                    Description = record.Description,
                    Created = record.Created

                };

                context.Records.Update(recordDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
