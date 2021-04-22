﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eweb.Common.DataAccessLayer;
namespace eweb.Controllers
{
    public class MenusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string CoreInquiry()
        {
            var v_result = string.Empty;
            var v_obj = new MongoDbHelper();
            var v_connectionString = "mongodb://HOST:*****@localhost:27017/?authSource=HOST&readPreference=primary&appname=MongoDB%20Compass&ssl=false";
            try
            {
                v_result = v_obj.ExecuteCMDReturnDataset(v_connectionString, "", "");
            }
            catch (Exception e)
            {
                v_result = "-1";
            }
            return v_result;
        }
    }
}
