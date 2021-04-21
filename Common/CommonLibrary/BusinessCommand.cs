using System;
using Eweb.Common.CommonLibrary;
namespace Eweb.Common.CommonLibrary
{
    public class BusinessCommand
    {
        private string mv_strUser;
        private string mv_dtmExecuteDate;
        private string mv_strExecuteTime;
        private string mv_strExecuteCMD;
        private Boolean mv_blnHasTransaction;
        private CommonConst v_const = new CommonConst();

        public string ExecuteUser { get {return mv_strUser;} set { mv_strUser = value;} }
        public string ExecuteDate { get {return mv_dtmExecuteDate;} set { mv_dtmExecuteDate = value;} }
        public string ExecuteTime { get {return mv_strExecuteTime;} set { mv_strExecuteTime = value;} }
        public string ExecuteCMD { get {return mv_strExecuteCMD;} set { mv_strExecuteCMD = value;} }
        public Boolean HasTransaction { get {return mv_blnHasTransaction;} set { mv_blnHasTransaction = value;} }
        public BusinessCommand()
        {
            ExecuteUser = String.Empty;
            ExecuteDate = DateTime.Now.ToString(v_const.get_datetime_format("DATE"));
            ExecuteTime = DateTime.Now.ToString(v_const.get_datetime_format("DATETIME"));
            ExecuteCMD = String.Empty;
            HasTransaction = false;
        }
    }
}