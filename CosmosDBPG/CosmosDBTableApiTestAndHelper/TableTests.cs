using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace CosmosDBTableApiTestAndHelper
{
    [TestClass]
    public class TableTests
    {
        [TestMethod]
        public void InfastructureTest()
        {
            TableApi t = new TableApi();
            string r = t.CheckDB();
            Console.WriteLine(r);
        }
        [TestMethod]
        public void TableDBTest_Person()
        {
            TableApi t = new TableApi();

            var l = t.GetPersons();
            foreach (var b in l)
            {
                Console.WriteLine(JsonConvert.SerializeObject(b));
            }

            t.CreatePerson(new Person() { PartitionKey = "Worker", RowKey=Guid.NewGuid().ToString() });

            l = t.GetPersons();
            foreach (var b in l)
            {
                Console.WriteLine(JsonConvert.SerializeObject(b));
            }

        }
    }
}
