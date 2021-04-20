using Eweb.Common.DataAccessLayer;
namespace Eweb.Common.DataAccessLayer
{
    public class MongoDbHelper
    {
        private DataAccessEngine _dataAccessEngine;
        public MongoDbHelper(DataAccessEngine dataAccessEngine)
        {
            _dataAccessEngine = dataAccessEngine;
        }
    }
}