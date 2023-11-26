using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.EntityFramework
{
    public class PasswordManagerDbContextFactory
    {
        private readonly Action<DbContextOptionsBuilder> _configureDbContext;

        public PasswordManagerDbContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
        {
            _configureDbContext = configureDbContext;
        }

        public PasswordManagerDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<PasswordManagerDbContext> options = new DbContextOptionsBuilder<PasswordManagerDbContext>();

            _configureDbContext(options);

            return new PasswordManagerDbContext(options.Options);
        }
    }
}
