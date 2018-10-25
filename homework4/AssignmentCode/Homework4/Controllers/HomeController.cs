﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace Homework4.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Converter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Converter(decimal miles, string units)
        {
            var multiplier = 0m;
            switch (units)
            {
                case  "Kilometers":
                    multiplier = 1.60934m;
                    break;
            }

            ViewBag.ConversionResult = $"{miles} Miles is equal to ${multiplier * miles}";

            return View();
        }
    }
}