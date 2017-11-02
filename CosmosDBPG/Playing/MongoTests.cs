using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CosmosDBHelper;
using System.Diagnostics;
using MongoDB.Bson;

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
            Console.WriteLine("ClusterConfigurator: {0}", Mongo.ForTest());
        }
        [TestMethod]
        public void BasicMongoTest()
        {
            Mongo m = new Mongo();
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
        public void UntypedMongoTest()
        {
            Mongo m = new Mongo();
            //m.ConfigureLogging();

            var t = m.GetObjects();
            Console.WriteLine(t);
        }
    }
}



