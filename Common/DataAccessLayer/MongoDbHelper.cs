using System;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;
using Eweb.Common.CommonLibrary;
using Newtonsoft.Json;

namespace Eweb.Common.DataAccessLayer
{
    public class MongoDbHelper
    {
        private DataAccessEngine _dataAccessEngine;
        public MongoDbHelper()
        {

        }

        public async Task<string> ExecuteCMDReturnDataset(string ConnectionString, string CommandType, string CommandText)
        {

            string username = "HOST";
            string password = "HOST";
            string mongoDbAuthMechanism = "SCRAM-SHA-1";
            MongoInternalIdentity internalIdentity =
                    new MongoInternalIdentity("HOST", username);
            PasswordEvidence passwordEvidence = new PasswordEvidence(password);
            MongoCredential mongoCredential =
                new MongoCredential(mongoDbAuthMechanism,
                        internalIdentity, passwordEvidence);
            List<MongoCredential> credentials =
                    new List<MongoCredential>() { mongoCredential };

            MongoClientSettings settings = new MongoClientSettings();
            // comment this line below if your mongo doesn't run on secured mode
            settings.Credentials = credentials;
            String mongoHost = "127.0.0.1";
            MongoServerAddress address = new MongoServerAddress(mongoHost);
            settings.Server = address;

            MongoClient client = new MongoClient(settings);

            var database = client.GetDatabase("HOST");
            //var mongoCollection = database.GetCollection<BsonDocument>("cmdmenu");

            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("cmdmenu");

            var findOptions = new FindOptions<BsonDocument>();

            findOptions.Projection = "{'_id': 0}";

            // Other options
            findOptions.Sort = Builders<BsonDocument>.Sort.Ascending("cmdid");
            findOptions.Limit = int.MaxValue;

            var filter = Builders<BsonDocument>.Filter.Empty;

            //var list = collection.Find(filter).Project(findOptions.Projection).Sort(findOptions.Sort);
            var list = collection.Find(filter).Project(findOptions.Projection).Sort(findOptions.Sort).ToList();

            return list.ToJson().ToString();
        }

        public async Task<string> ExecuteCMDReturnDatasetByFilter(string ConnectionString, string CommandType, string CommandText, string Filter)
        {

            string username = "HOST";
            string password = "HOST";
            string mongoDbAuthMechanism = "SCRAM-SHA-1";
            MongoInternalIdentity internalIdentity =
                    new MongoInternalIdentity("HOST", username);
            PasswordEvidence passwordEvidence = new PasswordEvidence(password);
            MongoCredential mongoCredential =
                new MongoCredential(mongoDbAuthMechanism,
                        internalIdentity, passwordEvidence);
            List<MongoCredential> credentials =
                    new List<MongoCredential>() { mongoCredential };

            MongoClientSettings settings = new MongoClientSettings();
            // comment this line below if your mongo doesn't run on secured mode
            settings.Credentials = credentials;
            String mongoHost = "127.0.0.1";
            MongoServerAddress address = new MongoServerAddress(mongoHost);
            settings.Server = address;

            MongoClient client = new MongoClient(settings);

            var database = client.GetDatabase("HOST");
            //var mongoCollection = database.GetCollection<BsonDocument>("cmdmenu");

            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("cmdmenu");

            var findOptions = new FindOptions<BsonDocument>();

            findOptions.Projection = "{'_id': 0}";

            // Other options
            findOptions.Sort = Builders<BsonDocument>.Sort.Ascending("cmdid");
            findOptions.Limit = int.MaxValue;

            //Filter
            List<JsonElement> jsonFilterList = new List<JsonElement>();
            jsonFilterList = JsonConvert.DeserializeObject<List<JsonElement>>(Filter);

            var builder = Builders<BsonDocument>.Filter;
            var listFilter = FilterDefinition<BsonDocument>.Empty;

            foreach (var item in jsonFilterList)
            {
                if (item.Datatype == "bool")
                {
                    //if (item.Operator == "=")
                    //{
                    //    builder = Builders<BsonDocument>.Filter.Eq()
                    //}
                    listFilter &= builder.Eq(item.Key, Convert.ToBoolean(item.Value));
                }
                else if (item.Datatype == "string")
                {
                    if (item.Operator == "=")
                    {
                        listFilter &= builder.Eq(item.Key, item.Value);
                    }
                    else if (item.Operator.ToUpper() == "LIKE")
                    {
                        listFilter &= builder.Regex(item.Key, new BsonRegularExpression($"/{item.Value}/"));
                    }
                }
                else if (item.Datatype == "number")
                {
                    if (item.Operator == "=")
                    {
                        listFilter &= builder.Eq(item.Key, Convert.ToDecimal(item.Value));
                    }
                    else if (item.Operator.ToUpper() == ">")
                    {
                        listFilter &= builder.Gt(item.Key, Convert.ToDecimal(item.Value));
                    }
                    else if (item.Operator.ToUpper() == "<")
                    {
                        listFilter &= builder.Lt(item.Key, Convert.ToDecimal(item.Value));
                    }
                    else if (item.Operator.ToUpper() == ">=")
                    {
                        listFilter &= builder.Gte(item.Key, Convert.ToDecimal(item.Value));
                    }
                    else if (item.Operator.ToUpper() == "<=")
                    {
                        listFilter &= builder.Lte(item.Key, Convert.ToDecimal(item.Value));
                    }
                }
            }
            var list = collection.Find(listFilter).Project(findOptions.Projection).Sort(findOptions.Sort).ToList();

            return list.ToJson().ToString();
        }
    }
}