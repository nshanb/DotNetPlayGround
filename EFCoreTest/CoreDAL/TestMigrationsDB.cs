using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDAL
{
    public class TestMigrationsDB : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = PC-0609; Initial Catalog = TestMigrations; Integrated Security = SSPI;Application Name=kuku");
        }
        public DbSet<InchvorBan1> InchvorBaner1 { get; set; }
        public DbSet<InchvorBan2> InchvorBaner2 { get; set; }
    }

    public class InchvorBan1
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
    public class InchvorBan2
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
