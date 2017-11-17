using Microsoft.Azure.CosmosDB.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDBTableApiTestAndHelper
{
    class Models
    {
    }

    public class Person : TableEntity
    {
        public Person(string title, string id)
        {
            PartitionKey = id;
            RowKey = title;
        }
        public Person()
        {
        }
        //public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
