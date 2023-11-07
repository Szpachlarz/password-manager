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
    public class CreateUserAccountCommand : ICreateUserAccountCommand
    {
        private readonly password_managerDbContextFactory _contextFactory;

        public CreateUserAccountCommand(password_managerDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(UserAccount user)
        {
            using (password_managerDbContext context = _contextFactory.Create())
            {
                UserAccountDto userDto = new UserAccountDto()
                {
                    Id = user.Id,
                    Username = user.Username,
                    Password = user.Password

                };

                context.UserAccounts.Add(userDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
