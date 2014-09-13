using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core;
using Core.DataAccess;

namespace UI.Controllers
{
    [VisitorRetrievalFilter(Order = 1)]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Message = "Please verify your info.";
            var visitor = new VisitorBuilder().BuildVisitor();
            return View(visitor);
        }

        [HttpPost]
        public ActionResult Index(Visitor visitor)
        {
            if (!ModelState.IsValid)
            {
                return View(visitor);
            }

            new VisitorRepository().Save(visitor);
            TempData.Add("message", "Your visit has been logged.");
            return RedirectToAction("index");
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
    }
}