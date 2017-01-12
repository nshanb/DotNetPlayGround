using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.sync4partner
{
    public class MainConfig
    {
        public int Id { get; set; }
        public DateTime LastSchemaConfig { get; set; }
        public DateTime LastSyncTableChange { get; set; }
        public char Working { get; set; }
    }
}
