using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.sync
{
    [Table("MainConfig", Schema = "sync4partner")]
    public class MainConfig
    {
        public int Id { get; set; }
        public DateTime LastSchemaConfig { get; set; }
        public DateTime LastSyncTableChange { get; set; }
        public string Working { get; set; }
    }
}
