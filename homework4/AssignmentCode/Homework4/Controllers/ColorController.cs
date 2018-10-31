using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework4.Models;
using WebGrease.Css;

namespace Homework4.Controllers
{
    [RoutePrefix("color")]
    public class ColorController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            var model = new ColorMixModel();
            return View(model);
        }

        [HttpPost]
        [Route("")]
        public ActionResult Post(ColorMixModel model)
        {
            if(string.IsNullOrWhiteSpace(model.PrimaryColor) || string.IsNullOrWhiteSpace(model.SecondaryColor))
                throw new ArgumentException("Missing either primary or secondary color.");

            var primaryColor = ColorTranslator.FromHtml(model.PrimaryColor);
            var secondaryColor = ColorTranslator.FromHtml(model.SecondaryColor);

            var r = (int)Math.Round((secondaryColor.R + primaryColor.R) / (2f),0);
            var g = (int)Math.Round((secondaryColor.G + primaryColor.G) / (2f), 0);
            var b = (int)Math.Round((secondaryColor.B + primaryColor.B) / (2f), 0);

            var mixedColor = Color.FromArgb(1, r, g, b);

            model.MixedColor = ColorTranslator.ToHtml(mixedColor);

            return View("Index", model);
        }
     }
}
