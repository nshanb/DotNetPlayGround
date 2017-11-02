using Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDBHelper
{
    public class Models
    {
        static IMyLogger PLogger = LoggerFactory.GetLogger("CosmosDBHelper");
    }
    public class Book
    {
        public ObjectId Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
    }

    public class Address
    {
        [BsonId(IdGenerator = typeof(CombGuidGenerator))]
        public Guid Id { get; set; }
        public string City { get; set; }
    }
}
