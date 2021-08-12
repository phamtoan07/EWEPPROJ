using Eweb.Common.CommonLibrary;
using Eweb.Common.Configurations;
using Eweb.Models.SA.Menu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eweb.ViewComponents
{
    public class ExtendMenuViewComponent : ViewComponent
    {
        private readonly IConfiguration Configuration;

        public ExtendMenuViewComponent(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await GetListExtendedCmdmenuAsync();
            return View(items);
        }

        public async Task<IEnumerable<cmdmenu>> GetListExtendedCmdmenuAsync()
        {
            IEnumerable<cmdmenu> _listMenu;
            var v_result = string.Empty;

            var connectionConfig = new ConnectionConfiguration();
            Configuration.GetSection(ConnectionConfiguration.ConnectionConfig).Bind(connectionConfig);

            var v_obj = new Eweb.HOSTService.HOSTService(connectionConfig);

            try
            {
                string v_strFilter = string.Empty;
                //build filter string json
                JsonElement filter;
                List<JsonElement> listFilter = new List<JsonElement>();

                filter = new JsonElement("display", "true", "=", "bool");
                listFilter.Add(filter);

                filter = new JsonElement("extended", "true", "=", "bool");
                listFilter.Add(filter);

                modCommond.BuildJsonFormat(listFilter, ref v_strFilter);
                v_result = await v_obj.ExcuteCmdReturnDataset(v_strFilter);
                _listMenu = await Task.Run(() => JsonConvert.DeserializeObject<List<cmdmenu>>(v_result));
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