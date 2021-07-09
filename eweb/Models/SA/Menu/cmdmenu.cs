using System.Diagnostics;
using Eweb.Models.Base;
namespace Eweb.Models.SA.Menu
{
    public class cmdmenu : IBaseModel
    {
        private string _cmdid;
        public string cmdid { get => _cmdid; set => _cmdid = value; }

        public cmdmenu(string v_strCMDID)
        {
            cmdid = v_strCMDID;
        }
    }
}
