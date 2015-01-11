using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using LApp.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LApp.Filters
{
    public class LAppContext : DbContext
    {
        public LAppContext(): base("LAppContext12")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}