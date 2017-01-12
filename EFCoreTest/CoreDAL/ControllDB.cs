using Microsoft.EntityFrameworkCore;
using Model.sync4partner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDAL
{
    public class ControllDB : DbContext
    {
        public DbSet<MainConfig> MainConfigs { get; set; }
		private void temp()
        {
            this.MainConfigs.Select(x => x.Id == 7);
        }
    }
}
