using System.Collections.Generic;
using System.Diagnostics;
using Eweb.HOSTService.Base;
namespace Eweb.HOST.SA
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
        private bool _extended;
        private List<cmdmenu> _listChild;


        public cmdmenu(string v_strCMDID, string v_strModcode, string v_strObjname, string v_strAuthcode,
                       string v_strPrid = "", long v_dblLev = 1, bool v_isLast = true, string v_strMenutype = "",
                       string v_strCmdname = "", string v_strTltxcd = "", string v_strMnviewcode = "",
                       bool v_isDisplay = true, bool v_isExtended = false)
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
            Extended = v_isExtended;
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
        public bool Extended { get => _extended; set => _extended = value; }
        public List<cmdmenu> ListChild { get => _listChild; set => _listChild = value; }

        public List<cmdmenu> getChildMenu(string cmdid, long lev, List<cmdmenu> list)
        {
            List<cmdmenu> ret = new List<cmdmenu>();

            if (lev == 0)
            {
                return ret;
            }

            ret = list.FindAll(x => (x.Lev == lev + 1 && x.Prid == cmdid));
            return ret;
        }
    }
}
