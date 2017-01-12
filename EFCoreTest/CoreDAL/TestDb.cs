using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDAL
{
    public class TestDB : DbContext
    {
        public TestDB(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
        public TestDB() : base()
        {
        }
        public DbSet<Test> Tests { get; set; }
    }
    public class Test
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
