using System.Web;
using System.Web.Mvc;
using TestTheTask.Models;

namespace TestTheTask.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult File()
        {
            ViewBag.Title = "File";

            return View("Upload");
        }

        public ActionResult Upload(HttpPostedFileBase upload)
        {
            Logic.Insert(upload);
            return RedirectToAction("Index");
        }
    }
}
