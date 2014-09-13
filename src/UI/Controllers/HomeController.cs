using System.Web.Mvc;
using Core;

namespace UI.Controllers
{
    [VisitorRetrievalFilter(Order = 1)]
    public class HomeController : Controller
    {
        private readonly IVisitorRepository _repository;

        public HomeController(IVisitorRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Message = "Please verify your info.";
            Visitor visitor = new VisitorBuilder().BuildVisitor();
            return View(visitor);
        }

        [HttpPost]
        public ActionResult Index(Visitor visitor)
        {
            if (!ModelState.IsValid)
            {
                return View(visitor);
            }

            _repository.Save(visitor);
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