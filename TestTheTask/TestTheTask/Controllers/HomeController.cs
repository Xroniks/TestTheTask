using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using TestTheTask.Models;
using TestTheTask.Services;

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
            ViewBag.ListContragents = LogicContragents.ParsFile(upload);
            return View();
        }

        [HttpPost]
        public ActionResult Upload(List<Contragent> Contragent)
        {
            LogicContragents.UploadinBd(Contragent);
            return View("Index");
        }
    }
}
