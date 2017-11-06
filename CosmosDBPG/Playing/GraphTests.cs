using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CosmosDBHelper;
using Newtonsoft.Json;
using CosmosDBHelper.Models;

namespace Playing
{
    [TestClass]
    public class GraphTests
    {
        [TestMethod]
        public void InfastructureTest()
        {
            GraphApi g = new GraphApi();
            string r = g.CheckDB();
            Console.WriteLine(r);
        }
        [TestMethod]
        public void GraphTest_People()
        {
            GraphApi d = new GraphApi();

            var l = d.GetPersons();
            foreach (var b in l)
            {
                Console.WriteLine(JsonConvert.SerializeObject(b));
            }

            string res = d.CreatePerson(new Person() { FirstName = "Nshan", LastName = "Barseghyan", Id = Guid.NewGuid().ToString() });
            Console.WriteLine(res);
            //l = d.GetPersons();
            //foreach (var b in l)
            //{
            //    Console.WriteLine(JsonConvert.SerializeObject(b));
            //}
        }
        [TestMethod]
        public void GraphTest_CountPeople()
        {
            GraphApi g = new GraphApi();
            string r = g.CountPersons();
            Console.WriteLine(r);
        }
        [TestMethod]
        public void GraphTest_GetPersons1()
        {
            GraphApi d = new GraphApi();

            string res = d.GetPersons1();
            Console.WriteLine(res);
        }
    }
}
