using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDBHelper
{
    public class Mongo
    {
        private const string _Host = "625bfdb2-0ee0-4-231-b9ee.documents.azure.com";
        private const string _UserName = "625bfdb2-0ee0-4-231-b9ee";
        private const string _pswd = "BbmGeMJDIPyZolfCE5qdlabtUqYimEbKP7Y64cLULJaOTbE5XOJUOhvb7Mno7dB8LYF8gmhhIL7ex2TLUyVVXw==";
        private const string _pswdRO = "BbmGeMJDIPyZolfCE5qdlabtUqYimEbKP7Y64cLULJaOTbE5XOJUOhvb7Mno7dB8LYF8gmhhIL7ex2TLUyVVXw==";
        private const string _dbName = "Library";

        private MongoClientSettings _ClientSettingsRW;
        private MongoClientSettings _ClientSettingsRO;
        public Mongo()
        {
            MongoIdentity identity;
            MongoIdentityEvidence evidence;

            _ClientSettingsRW = new MongoClientSettings();
            _ClientSettingsRW.Server = new MongoServerAddress(_Host, 10255);
            _ClientSettingsRW.UseSsl = true;
            _ClientSettingsRW.SslSettings = new SslSettings();
            _ClientSettingsRW.SslSettings.EnabledSslProtocols = SslProtocols.Tls12;
            identity = new MongoInternalIdentity("globaldb", _UserName);
            evidence = new PasswordEvidence(_pswd);

            _ClientSettingsRW.Credentials = new List<MongoCredential>()
            {
                new MongoCredential("SCRAM-SHA-1", identity, evidence)
            };


            _ClientSettingsRO = _ClientSettingsRW.Clone();
            identity = new MongoInternalIdentity("globaldb", _UserName);
            evidence = new PasswordEvidence(_pswdRO);
            _ClientSettingsRO.Credentials = new List<MongoCredential>()
            {
                new MongoCredential("SCRAM-SHA-1", identity, evidence)
            };

        }

        public void ConfigureLogging()
        {
            _ClientSettingsRW.ClusterConfigurator = cb => configureLogging(cb);
            _ClientSettingsRO.ClusterConfigurator = cb => configureLogging(cb);
        }

        private TraceSource __traceSource;
        private void configureLogging(ClusterBuilder builder)
        {
            __traceSource = new TraceSource("mongodb-tests", SourceLevels.All);
            __traceSource.Listeners.Clear(); // remove the default listener
            var listener = new TextWriterTraceListener(Console.Out);
            listener.TraceOutputOptions = TraceOptions.DateTime;
            __traceSource.Listeners.Add(listener);
            
            //        var textWriter = TextWriter.Synchronized(new StreamWriter("mylogfile.txt"));
            //        builder.AddListener(new LogListener(textWriter));

            //builder.TraceWith(__traceSource);
            builder.TraceCommandsWith(__traceSource);
        }
        public static object ForTest()
        {
            MongoClientSettings settings = new MongoClientSettings();
            return settings.ToJson();
        }
        public List<Book> GetBooks()
        {
            MongoClient client = new MongoClient(_ClientSettingsRO);
            IMongoDatabase database = client.GetDatabase(_dbName);
            IMongoCollection<Book> books = database.GetCollection<Book>("Book");
            return books.Find(new BsonDocument()).ToList();
        }
        public string GetObjects()
        {
            MongoClient client = new MongoClient(_ClientSettingsRO);
            IMongoDatabase database = client.GetDatabase(_dbName);
            IMongoCollection<BsonDocument> books = database.GetCollection<BsonDocument>("Book");
            return books.Find(new BsonDocument()).ToList().ToJson();
        }
        public void CreateBook(Book aBook)
        {
            MongoClient client = new MongoClient(_ClientSettingsRW);
            IMongoDatabase database = client.GetDatabase(_dbName);
            IMongoCollection<Book> books = database.GetCollection<Book>("Book");
            books.InsertOne(aBook);
        }
    }
}
