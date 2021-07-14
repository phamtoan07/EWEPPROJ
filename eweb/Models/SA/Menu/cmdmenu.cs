using System.Diagnostics;
using Eweb.Models.Base;
namespace Eweb.Models.SA.Menu
{
    public class cmdmenu : IBaseModel
    {
        private string _cmdid;
        private string _prid;
        private long _lev;
        private bool _last;
        private string _menutype;
        private string _modcode;
        private string _objname;
        private string _cmdname;
        private string _authcode;
        private string _tltxcd;
        private string _mnviewcode;
        private bool _display;


        public cmdmenu(string v_strCMDID, string v_strModcode, string v_strObjname, string v_strAuthcode,
                       string v_strPrid = "", long v_dblLev = 1, bool v_isLast = true, string v_strMenutype = "", 
                       string v_strCmdname = "", string v_strTltxcd = "", string v_strMnviewcode = "", bool v_isDisplay = true)
        {
            Cmdid = v_strCMDID;
            Prid = v_strPrid;
            Lev = v_dblLev;
            Last = v_isLast;
            Menutype = v_strMenutype;
            Modcode = v_strModcode;
            Objname = v_strObjname;
            Cmdname = v_strCmdname;
            Authcode = v_strAuthcode;
            Tltxcd = v_strTltxcd;
            Mnviewcode = v_strMnviewcode;
            Display = v_isDisplay;
        }
        public cmdmenu()
        {

        }

        public string Cmdid { get => _cmdid; set => _cmdid = value; }
        public string Prid { get => _prid; set => _prid = value; }
        public long Lev { get => _lev; set => _lev = value; }
        public bool Last { get => _last; set => _last = value; }
        public string Menutype { get => _menutype; set => _menutype = value; }
        public string Modcode { get => _modcode; set => _modcode = value; }
        public string Objname { get => _objname; set => _objname = value; }
        public string Cmdname { get => _cmdname; set => _cmdname = value; }
        public string Authcode { get => _authcode; set => _authcode = value; }
        public string Tltxcd { get => _tltxcd; set => _tltxcd = value; }
        public string Mnviewcode { get => _mnviewcode; set => _mnviewcode = value; }
        public bool Display { get => _display; set => _display = value; }
    }
}
