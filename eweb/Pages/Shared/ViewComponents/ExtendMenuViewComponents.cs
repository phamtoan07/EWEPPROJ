using System;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Eweb.Models.SA.Menu;
using System.Collections.Generic;
using Eweb.Common.DataAccessLayer;
using System.Threading.Tasks;
using System.Linq;

namespace Eweb.ViewComponents
{
    public class ExtendMenuViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await GetListCmdmenuAsync();
            return View(items);
        }

        public async Task<IEnumerable<cmdmenu>> GetListCmdmenuAsync()
        {
            IEnumerable<cmdmenu> _listMenu;
            var v_result = string.Empty;
            var v_obj = new MongoDbHelper();
            var v_connectionString = "mongodb://HOST:*****@localhost:27017/?authSource=HOST&readPreference=primary&appname=MongoDB%20Compass&ssl=false";
            try
            {
                v_result = await v_obj.ExecuteCMDReturnDatasetByFilter(v_connectionString, "", "");
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