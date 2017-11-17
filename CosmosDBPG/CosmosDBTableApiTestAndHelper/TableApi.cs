using Microsoft.Azure.CosmosDB.Table;
using Microsoft.Azure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDBTableApiTestAndHelper
{
    public class TableApi
    {
        private const string _AccountName = "625bfdb2-0ee0-4-231-b9ee";
        private static readonly string _AUTHKEY = System.Configuration.ConfigurationManager.AppSettings["pswd"];

        private CloudTableClient tableClient;
        public TableApi()
        {
            string _PremiumStorageConnectionString;
            CloudStorageAccount storageAccount;

            _PremiumStorageConnectionString = $"DefaultEndpointsProtocol=https;AccountName={_AccountName};AccountKey={_AUTHKEY};TableEndpoint=https://625bfdb2-0ee0-4-231-b9ee.documents.azure.com";

            storageAccount = CloudStorageAccount.Parse(_PremiumStorageConnectionString);
            tableClient = storageAccount.CreateCloudTableClient();
        }

        public string CheckDB()
        {
            CloudTable table = tableClient.GetTableReference("People");
            // created TablesDB.People
            table.CreateIfNotExists();
            return table.Name;
        }

        public List<Person> GetPersons()
        {
            CloudTable table = tableClient.GetTableReference("People");
            TableQuery<Person> rangeQuery = new TableQuery<Person>();
            List<Person> p = table.ExecuteQuery(rangeQuery).ToList();
            return p;
        }
        public void CreatePerson(Person aPerson)
        {
            CloudTable table = tableClient.GetTableReference("People");
            TableOperation insertOperation = TableOperation.Insert(aPerson);
            table.Execute(insertOperation);
        }

    }
}
