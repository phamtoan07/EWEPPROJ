using System;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Text.Json;
using System.Threading.Tasks;

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

        public async Task<string> ExecuteCMDReturnDatasetByFilter(string ConnectionString, string CommandType, string CommandText)
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
    }
}