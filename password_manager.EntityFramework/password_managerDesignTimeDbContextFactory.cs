using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace password_manager.EntityFramework
{
    public class password_managerDesignTimeDbContextFactory : IDesignTimeDbContextFactory<password_managerDbContext>
    {
        public password_managerDbContext CreateDbContext(string[] args = null)
        {
            return new password_managerDbContext(new DbContextOptionsBuilder().UseSqlite("Data Source=PasswordManager.db").Options);
        }
    }
}
