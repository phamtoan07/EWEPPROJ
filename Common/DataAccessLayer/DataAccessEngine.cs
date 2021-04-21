using Eweb.Common.CommonLibrary;
using System.Data;
namespace Eweb.Common.DataAccessLayer
{
    public class DataAccessEngine
    {
        private string mv_strConnectionString;
        private string mv_strModule;
        private string mv_dbProvider;

        private string mv_blnLogCommand;

        private string mv_strLogFileName;

        const string  c_LogCommandFilePath = "LogCommandFilePath";
        public string ConnectionString { get {return mv_strConnectionString;} set { mv_strConnectionString = value;} }

        public DataAccessEngine(string strConnectionString)
        {
            mv_strConnectionString = strConnectionString;
        }
        
        public DataSet ExecuteSQLReturnDataset(BusinessCommand pv_bCommand)
        {
            DataSet v_ds = new DataSet();

            return v_ds;
        }
    }
}