using CosmosDBHelper.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDBHelper
{
    public class DocDBapi
    {
        private static readonly string _DatabaseId = "Library";
        private static readonly string _pswd = System.Configuration.ConfigurationManager.AppSettings["pswd"];
        private static readonly string _CollectionId = "Article";

        private DocumentClient _Client;
        public DocDBapi()
        {
            _Client = new DocumentClient(new Uri("https://625bfdb2-0ee0-4-231-b9ee.documents.azure.com"), _pswd);
        }
        public string CheckDB()
        {
            ResourceResponse<Database> x = _Client.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(_DatabaseId)).Result;
            return x.Resource.ToString();
        }

        public List<Article> GetArticles()
        {
            Uri collectionLink = UriFactory.CreateDocumentCollectionUri(_DatabaseId, _CollectionId);
            IDocumentQuery<Article> query = _Client.CreateDocumentQuery<Article>(collectionLink, new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                .Where(_ => true).AsDocumentQuery();

            List<Article> result = new List<Article>();
            while (query.HasMoreResults)
            {
                result.AddRange(query.ExecuteNextAsync<Article>().Result);
            }
            return result;
        }
        public void CreateArticle(Article aBook)
        {
            Uri collectionLink = UriFactory.CreateDocumentCollectionUri(_DatabaseId, _CollectionId);
            _Client.CreateDocumentAsync(collectionLink, aBook);
        }
    }
}
