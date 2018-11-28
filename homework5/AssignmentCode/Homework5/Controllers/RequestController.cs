using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework5.DAL;

namespace Homework5.Controllers
{
    public class RequestController : Controller
    {
        // GET: Request
        public ActionResult Index()
        {
            using (var db = new RequestContext())
            {
                var requests = db.Requests.ToList();
                return View(requests);
            }

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Request request)
        {
            try
            {
                using (var db = new RequestContext())
                {
                    request.CreateDate = DateTime.Now;
                    db.Requests.Add(request);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(request);
            }
        }
    }
}
