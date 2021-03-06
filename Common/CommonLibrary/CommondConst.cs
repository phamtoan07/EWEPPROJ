using System.Globalization;
using System.Collections.Generic;
namespace Eweb.Common.CommonLibrary
{
    public class CommonConst
    {
        public const string gc_const_datetime_provider = "vi-VN";

        public const string gc_const_getdatetime = "DATETIME";
        public const string gc_const_getdate = "DATE";
        public const string gc_const_gettime = "TIME";

        public string get_datetime_format(string v_strType)
        {
            CultureInfo v_provider = new CultureInfo(gc_const_datetime_provider);
            string v_strFormat = string.Empty;
            switch (v_strType)
            {
                case gc_const_getdatetime:
                    v_strFormat = v_provider.DateTimeFormat.FullDateTimePattern;
                    break;
                case gc_const_getdate:
                    v_strFormat = v_provider.DateTimeFormat.ShortDatePattern;
                    break;
                case gc_const_gettime:
                    v_strFormat = v_provider.DateTimeFormat.ShortTimePattern;
                    break;
                default:
                    break;
            }
            return v_strFormat;
        }

        #region Error code constants
        public const long ERR_SYSTEM_OK = 0;
        public const long ERR_SYSTEM_START = ERR_SYSTEM_OK - 1;
        #endregion

        #region Message schema
        public string gc_SCHEMA_OBJMESSAGE_HEADER = "[";
        public string gc_SCHEMA_OBJMESSAGE_FOOTER = "\n]";
        public IEnumerable<string> gc_KeyMsg = new string[]
        { "TXDATE", "TXNUM", "TXTIME", "TELLERID", "BRID", "LOCAL", "MSGTYPE",
          "OBJNAME", "ACTIONFLAG", "CMDINQUIRY", "CLAUSE", "FUNCTIONANE", "AUTOID",
          "REFERENCE", "RESERVER", "IPADDRESS", "CMDTYPE", "PARENTOBJNAME", "PARENTCLAUSE"
        };
        #endregion

        public CommonConst() { }
    }
}