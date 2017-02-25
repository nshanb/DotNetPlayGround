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
            optionsBuilder.UseSqlServer("Data Source = PC-0609; Initial Catalog = TestMigrations1; Integrated Security = SSPI;Application Name=kuku");
        }
        public DbSet<Smthing1> Somthing1 { get; set; }
        public DbSet<Smthing2> Somthing2 { get; set; }
        public DbSet<Smthing3> Somthing3 { get; set; }
    }

    public class Smthing1
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public IList<Smthing2> ban2ner { get; set; }
    }
    public class Smthing2
    {
        public int Id { get; set; }
        public string Text { get; set; }
        //public Smthing1 ban1 { get; set; }
    }
    public class Smthing3
    {
        public int Id { get; set; }
        public string Text { get; set; }
        //public InchvorBan1 ban1 { get; set; }
    }
}
