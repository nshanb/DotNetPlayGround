using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CosmosDBHelper;
using System.Diagnostics;
using MongoDB.Bson;
using CosmosDBHelper.Models;

namespace Playing
{
    [TestClass]
    public class MongoTests
    {
        [ClassInitialize]
        static public void ClassInit(TestContext context)
        {

        }
        [TestMethod]
        public void InfastructureTest()
        {
            Console.WriteLine("ClusterConfigurator: {0}", MongoApi.ForTest());
        }
        [TestMethod]
        public void MongoTest_Book()
        {
            MongoApi m = new MongoApi();
            //m.ConfigureLogging();

            var l = m.GetBooks();
            foreach (var b in l)
            {
                Console.WriteLine(b.ToJson());
            }
            m.CreateBook(new Book() { Author = "Nshan", Title="My first book" });

            l = m.GetBooks();
            foreach (var b in l)
            {
                Console.WriteLine(b.ToJson());
            }
        }
        [TestMethod]
        public void MongoTest_Address()
        {
            MongoApi m = new MongoApi();
            //m.ConfigureLogging();

            var l = m.GetAddresses();
            foreach (var b in l)
            {
                Console.WriteLine(b.ToJson());
            }
            m.CreateAddress(new Address() { City = "Nshan" });

            l = m.GetAddresses();
            foreach (var b in l)
            {
                Console.WriteLine(b.ToJson());
            }
        }
        [TestMethod]
        public void UntypedMongoTest()
        {
            MongoApi m = new MongoApi();
            //m.ConfigureLogging();

            var t = m.GetObjects();
            Console.WriteLine(t);
        }
    }
}



