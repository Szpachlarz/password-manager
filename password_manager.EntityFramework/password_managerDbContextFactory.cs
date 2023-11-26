using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace password_manager.EntityFramework
{
    public class password_managerDbContextFactory
    {
        private readonly Action<DbContextOptionsBuilder> _configureDbContext;

        public password_managerDbContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
        {
            _configureDbContext = configureDbContext;
        }

        public password_managerDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<password_managerDbContext> options = new DbContextOptionsBuilder<password_managerDbContext>();

            _configureDbContext(options);

            return new password_managerDbContext(options.Options);
        }
    }
}
