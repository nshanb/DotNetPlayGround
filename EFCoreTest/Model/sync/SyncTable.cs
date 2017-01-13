using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model.sync
{
    public class SyncTable
    {
        [Key]
        public string Name { get; set; }
        public bool ToCopy { get; set; }
        public bool ToStage { get; set; }
        public bool OnlyInsert { get; set; }
        public bool FullJoin { get; set; }
        public bool NeedsUpsert { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public int ObjectTypeId { get; set; }
        public string PartnerSpec { get; set; }
        public string PartnerSpec1 { get; set; }
    }
}
