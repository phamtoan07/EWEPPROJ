using System;
using System.Data;
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
        public string ExecuteCMDReturnDataset(string ConnectionString, string CommandType, string CommandText)
        {
            string ds  = string.Empty;

            var client = new MongoClient(ConnectionString);
            var database = client.GetDatabase("HOST");
            var  v_collection = database.GetCollection<BsonDocument>("cmdmenu");
            ds = v_collection.ToString();

            return ds;
        }
    }
}