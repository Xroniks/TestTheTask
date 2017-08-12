using System.Collections.Generic;
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

            return View();
        }

        public ActionResult Prewiew(HttpPostedFileBase upload)
        {
            ViewBag.ListContragents = Logic.Insert(upload);
            return View();
        }

        [HttpPost]
        public ActionResult Upload(List<Contragent> Contragent)
        {
            Logic.UploadinBd(Contragent);
            return View("Index");
        }
    }
}
