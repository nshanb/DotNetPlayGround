using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CosmosDBHelper;
using CosmosDBHelper.Models;
using Newtonsoft.Json;

namespace Playing
{
    [TestClass]
    public class DocDBTests
    {
        [TestMethod]
        public void InfastructureTest()
        {
            DocDBapi d = new DocDBapi();
            string r = d.CheckDB();
            Console.WriteLine(r);
        }
        [TestMethod]
        public void DocDBTest_Book()
        {
            DocDBapi d = new DocDBapi();

            var l = d.GetArticles();
            foreach (var b in l)
            {
                Console.WriteLine(JsonConvert.SerializeObject(b));
            }

            d.CreateArticle(new Article() { Author = "Nshan DB", Title = "My first book" });

            l = d.GetArticles();
            foreach (var b in l)
            {
                Console.WriteLine(JsonConvert.SerializeObject(b));
            }

        }
    }
}