using System;
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
        [Route("Converter")]
        public ActionResult Converter(decimal miles = 0, string units = "")
        {
            var conversion = 0m;
            switch (units)
            {
                case "millimeter":
                    conversion = Math.Round(1.60934m * 1000000 * miles, 3);
                    break;
                case "centimeter":
                    conversion = Math.Round(1.60934m * 100000 * miles, 3);
                    break;
                case "meter":
                    conversion = Math.Round(1.60934m * 1000 * miles, 3);
                    break;
                case "kilometer":
                    conversion = Math.Round(1.60934m * miles, 3);
                    break;
            }

            if (conversion != 0)
                ViewBag.ConversionResult = $"{miles} mile(s) is equal to {conversion} {units}(s)";

            return View();
        }
    }
}