using Eweb.Common.CommonLibrary;
using Eweb.Common.Configurations;
using Eweb.HOST.SA;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eweb.ViewComponents
{
    public class MenuBarViewComponent : ViewComponent
    {
        private readonly IConfiguration Configuration;

        public MenuBarViewComponent(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await GetListCmdmenuAsync();
            return View(items);
        }

        public async Task<IEnumerable<cmdmenu>> GetListCmdmenuAsync()
        {
            List<cmdmenu> _listMenu;
            var v_result = string.Empty;

            var connectionConfig = new ConnectionConfiguration();
            Configuration.GetSection(ConnectionConfiguration.ConnectionConfig).Bind(connectionConfig);

            var v_obj = new Eweb.BDSService.BDSService(connectionConfig);

            try
            {
                string v_strFilter = string.Empty;
                string objMessage = string.Empty;
                //build filter string json
                JsonFilterElement filter;
                List<JsonFilterElement> listFilter = new List<JsonFilterElement>();

                filter = new JsonFilterElement("display", "true", "=", "bool");
                listFilter.Add(filter);

                filter = new JsonFilterElement("extended", "false", "=", "bool");
                listFilter.Add(filter);

                modCommond.BuildJsonFormat(listFilter, ref v_strFilter);
                v_result = await v_obj.ExcuteCmdReturnDatasetByFilter(v_strFilter);

                objMessage = modCommond.BuildXMLObjMsg(pv_strTxDate: "07/10/1992",
                                                       pv_strBranchId: "0001",
                                                       pv_strTxTime: "06:01:00 AM",
                                                       pv_strLocal: "N",
                                                       pv_strTellerId: "0001",
                                                       pv_strObjName: "CMDMENU",
                                                       pv_strCmdType: "T",
                                                       pv_strIPAddress: "192.168.1.102",
                                                       pv_strActionFlag: "GET",
                                                       pv_strClause: v_strFilter
                                                       );

                _listMenu = await Task.Run(() => JsonConvert.DeserializeObject<List<cmdmenu>>(v_result));

                for (int i = 0; i < _listMenu.Count; i++)
                {
                    _listMenu[i].ListChild = _listMenu[i].getChildMenu(_listMenu[i].Cmdid, _listMenu[i].Lev, _listMenu);
                }

                return _listMenu;
            }
            catch (Exception e)
            {
                v_result = "-1";
                return Enumerable.Empty<cmdmenu>();
            }
        }
    }
}