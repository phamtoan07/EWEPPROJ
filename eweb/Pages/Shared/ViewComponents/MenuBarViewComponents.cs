using Eweb.Common.Configurations;
using Eweb.Common.DataAccessLayer;
using Eweb.Models.SA.Menu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            IEnumerable<cmdmenu> _listMenu;
            var v_result = string.Empty;

            var connectionConfig = new ConnectionConfiguration();
            Configuration.GetSection(ConnectionConfiguration.ConnectionConfig).Bind(connectionConfig);

            var v_obj = new MongoDbHelper(connectionConfig);
            var v_connectionString = "mongodb://HOST:*****@localhost:27017/?authSource=HOST&readPreference=primary&appname=MongoDB%20Compass&ssl=false";
            try
            {
                v_result = await v_obj.ExecuteCMDReturnDataset(v_connectionString, "", "");
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