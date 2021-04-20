using MongoDB.Bson;
using MongoDB.Driver;
namespace Eweb.Common.DataAccessLayer
{
    public class DataAccessEngine
    {
        private string _strConnectionString;

        public DataAccessEngine(string strConnectionString)
        {
            _strConnectionString = strConnectionString;
        }
        public MongoClient ConnectToMongoDB()
        {
            var client = new MongoClient(_strConnectionString);
            return client;
        }
    }
}