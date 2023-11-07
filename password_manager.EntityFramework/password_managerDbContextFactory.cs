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
        private readonly DbContextOptions _options;

        public password_managerDbContextFactory(DbContextOptions options)
        {
            _options = options;
        }
        public password_managerDbContext Create()
        {
            return new password_managerDbContext(_options);
        }
    }
}
