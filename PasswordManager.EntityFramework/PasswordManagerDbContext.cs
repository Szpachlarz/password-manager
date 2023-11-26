﻿using Microsoft.EntityFrameworkCore;
using PasswordManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.EntityFramework
{
    public class PasswordManagerDbContext : DbContext
    {
        public PasswordManagerDbContext(DbContextOptions options) : base(options) { }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Record> Records { get; set; }
    }
}
