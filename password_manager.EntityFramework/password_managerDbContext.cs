using Microsoft.EntityFrameworkCore;
using password_manager.EntityFramework.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace password_manager.EntityFramework
{
    public class password_managerDbContext : DbContext
    {
        public password_managerDbContext(DbContextOptions options) : base(options) { }

        public DbSet<UserAccountDto> UserAccounts { get; set; }
        public DbSet<RecordDto> Records { get; set; }
    }
}
