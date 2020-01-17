using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DAL.Interface.Interfaces
{
    public class AccountContext : DbContext
    {
        public AccountContext() : base("Accounts")
        {
            Database.SetInitializer<AccountContext>(new DropCreateDatabaseAlways<AccountContext>());
        }

        public DbSet<DalAccount> Accounts { get; set; }
    }
}
