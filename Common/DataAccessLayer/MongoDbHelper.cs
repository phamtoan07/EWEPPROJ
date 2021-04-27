using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Eweb.Common.DataAccessLayer;
using MongoDB.Driver;
using MongoDB.Bson;
namespace Eweb.Common.DataAccessLayer
{
    public class MongoDbHelper
    {
        private DataAccessEngine _dataAccessEngine;
        public MongoDbHelper()
        {
            
        }

        [Obsolete]
        public Object ExecuteCMDReturnDataset(string ConnectionString, string CommandType, string CommandText)
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
                    new List<MongoCredential>() {mongoCredential};


            MongoClientSettings settings = new MongoClientSettings();
            // comment this line below if your mongo doesn't run on secured mode
            settings.Credentials = credentials;
            String mongoHost = "127.0.0.1";
            MongoServerAddress address = new MongoServerAddress(mongoHost);
            settings.Server = address;

            MongoClient client = new MongoClient(settings);

            var database = client.GetDatabase("HOST");
            var mongoCollection = database.GetCollection<BsonDocument>("cmdmenu");
            var documents = mongoCollection.AsQueryable();

            var v_strJson =  documents.ToList().ConvertAll(BsonTypeMapper.MapToDotNetValue);

            return v_strJson;
        }
    }
}