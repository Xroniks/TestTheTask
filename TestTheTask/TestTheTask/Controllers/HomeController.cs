using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public ActionResult Upload(HttpPostedFileBase upload, ContrAgentContext db)
        {
            List<ContrAgent> Listcontragent = new List<ContrAgent>();
            Console.OutputEncoding = Encoding.GetEncoding(1251);
            string line;
            string[] masinf = new string[3];
            string s1 = "ПлательщикСчет=";
            string s2 = "Плательщик1=";
            string s3 = "ПлательщикИНН=";
            if (upload != null)
            {
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                // сохраняем файл в папку Files в проекте
                upload.SaveAs("D:/" + fileName);
                string fileput = "D:/" + fileName;
            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(fileput, Encoding.Default);
            while ((line = file.ReadLine()) != null)
            {
                if (line.IndexOf(s1) > -1)
                    masinf[0] = Regex.Replace(line, s1, String.Empty);
                if (line.IndexOf(s2) > -1)
                    masinf[1] = Regex.Replace(line, s2, String.Empty);
                if (line.IndexOf(s3) > -1)
                {
                    masinf[2] = Regex.Replace(line, s3, String.Empty);
                    Listcontragent.Add(new ContrAgent() { Name = masinf[1], Сheck = masinf[0], INN = masinf[2] });
                }
            }
            file.Close();
                }
            foreach (var contrag in Listcontragent)
            {
                db.ContrAgents.Add(contrag);
                db.SaveChanges();
            }
            db.SaveChanges();
            return View("Index");
        }

        public ActionResult File()
        {
            ViewBag.Title = "File";

            return View("Upload");
        }
    }
}
