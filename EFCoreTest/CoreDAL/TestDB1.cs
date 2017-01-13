using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDAL
{
    public class TestDB1 : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase();
        }
        public DbSet<Test1> Tests { get; set; }
    }
    public class Test1
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
