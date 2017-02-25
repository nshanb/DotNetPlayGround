using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Model.sync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace CoreDAL
{
    public class ControllDB : DbContext
    {
        static public IMyLogger CoreDALLogger = LoggerFactory.GetLogger("CoreDAL");
        public ControllDB(DbContextOptions<ControllDB> options) : base(options)
        {
            CoreDALLogger.Trace("ControllDB constructor");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            CoreDALLogger.Trace("ControllDB OnConfiguring");
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Entity<MainConfig>
                (e =>
                {
                    e.Property(o => o.LastSchemaConfig).HasDefaultValueSql("'1879-03-19'");
                    e.Property(o => o.LastSyncTableChange).HasDefaultValueSql("sysdatetime()");
                    e.Property(o => o.Working).HasColumnType("char(1)").HasDefaultValue("I");
                }
                );
        }
        public DbSet<MainConfig> MainConfigs { get; set; }
        public DbSet<SyncTable> SyncTables { get; set; }
        private void temp()
        {
            this.MainConfigs.Select(x => x.Id == 7);
            // Microsoft.EntityFrameworkCore.Infrastructure.
            //Microsoft.Data.Entity.Infrastructure.Database
            this.Database.GetDbConnection();
        }
    }

    public class ControllDBContextFactory : IDbContextFactory<ControllDB>
    {
        public ControllDB Create(DbContextFactoryOptions options)
        {
            ControllDB.CoreDALLogger.Trace("ControllDBContextFactory Create");
            var optionsBuilder = new DbContextOptionsBuilder<ControllDB>();
            optionsBuilder.UseInMemoryDatabase();

            return new ControllDB(optionsBuilder.Options);
        }
    }
}
