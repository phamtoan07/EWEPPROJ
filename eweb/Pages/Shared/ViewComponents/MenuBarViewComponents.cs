using System;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Eweb.Models.SA.Menu;
using System.Collections.Generic;
using Eweb.Common.DataAccessLayer;


namespace WebApplication.ViewComponents {
    public class MenuBarViewComponent : ViewComponent {
        public List<cmdmenu> _listMenu;
        public IViewComponentResult Invoke() {
            var v_result = String.Empty;
            var v_obj = new MongoDbHelper();
            var v_connectionString = "mongodb://HOST:*****@localhost:27017/?authSource=HOST&readPreference=primary&appname=MongoDB%20Compass&ssl=false";
            try
            {
                v_result = v_obj.ExecuteCMDReturnDataset(v_connectionString, "", "");
                _listMenu = JsonConvert.DeserializeObject<List<cmdmenu>>(v_result);
            }
            catch (Exception e)
            {
                v_result = "-1";
            }
            return View(_listMenu);
        }
    }
}