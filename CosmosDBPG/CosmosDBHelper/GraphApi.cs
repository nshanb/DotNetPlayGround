using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents;

using Microsoft.Azure.Graphs;
using Microsoft.Azure.Graphs.Elements;
using CosmosDBHelper.Models;
using Microsoft.Azure.Documents.Linq;
using Newtonsoft.Json;

namespace CosmosDBHelper
{
    public class GraphApi
    {
        private static readonly string authKey = System.Configuration.ConfigurationManager.AppSettings["pswd"];
        private static readonly string endpoint = "https://625bfdb2-0ee0-4-231-b9ee.documents.azure.com";
        DocumentClient client;
        public GraphApi()
        {
            client = new DocumentClient(new Uri(endpoint),authKey,new ConnectionPolicy { ConnectionMode = ConnectionMode.Direct, ConnectionProtocol = Protocol.Tcp });
        }

        public string CheckDB()
        {
            Database database = client.CreateDatabaseIfNotExistsAsync(new Database { Id = "graphdb" }).Result;
            ResourceResponse<Database> x = client.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(database.Id)).Result;
            return x.Resource.ToString();
        }
        public List<Person> GetPersons()
        {
            DocumentCollection graph = client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri("graphdb"),new DocumentCollection { Id = "people" },
                new RequestOptions { OfferThroughput = 1000 }).Result;

            IDocumentQuery<Person> query = client.CreateGremlinQuery<Person>(graph, "g.V()");

            List<Person> result = new List<Person>();
            while (query.HasMoreResults)
            {
                result.AddRange(query.ExecuteNextAsync<Person>().Result);
            }
            return result;
        }
        public string GetPersons1()
        {
            DocumentCollection graph = client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri("graphdb"), new DocumentCollection { Id = "people" },
                new RequestOptions { OfferThroughput = 1000 }).Result;

            IDocumentQuery<Person> query = client.CreateGremlinQuery<Person>(graph, "g.V()");

            string str = "";
            while (query.HasMoreResults)
            {
                foreach (dynamic result in query.ExecuteNextAsync().Result)
                {
                    str += $"\t {JsonConvert.SerializeObject(result)}";
                }
            }
            return str;
        }
        public string CreatePerson(Person aPerson)
        {
            Uri collectionLink = UriFactory.CreateDocumentCollectionUri("graphdb", "people");
            // didn't work
            // client.CreateDocumentAsync(collectionLink, aPerson);
            DocumentCollection graph = client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri("graphdb"), new DocumentCollection { Id = "people" },
               new RequestOptions { OfferThroughput = 1000 }).Result;
            IDocumentQuery<Person> query = client.CreateGremlinQuery<Person>(graph, $"g.addV('person').property('Id', '{aPerson.Id}').property('FirstName', '{aPerson.FirstName}').property('LastName', '{aPerson.LastName}')");

            string str = "";
            while (query.HasMoreResults)
            {
                foreach (dynamic result in query.ExecuteNextAsync().Result)
                {
                    str += $"\t {JsonConvert.SerializeObject(result)}";
                }
            }
            return str;
        }
        public string CountPersons()
        {
            DocumentCollection graph = client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri("graphdb"), new DocumentCollection { Id = "people" },
                new RequestOptions { OfferThroughput = 1000 }).Result;

            IDocumentQuery<dynamic> query = client.CreateGremlinQuery<dynamic>(graph, "g.V().count()");

            string str = "";
            while (query.HasMoreResults)
            {
                foreach (dynamic result in query.ExecuteNextAsync().Result)
                {
                    str += $"\t {JsonConvert.SerializeObject(result)}";
                }
            }
            return str;
        }
    }
}
