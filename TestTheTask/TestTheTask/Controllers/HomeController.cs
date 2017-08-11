using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using TestTheTask.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;


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

        public ActionResult Upload(HttpPostedFileBase upload/*, ContrAgentContext db*/)
        {
            Logic.Insert(upload);
            return RedirectToAction("Index");
            //List<ContrAgent> Listcontragent = new List<ContrAgent>();
            ////Console.OutputEncoding = Encoding.GetEncoding(1251);
            //string line;
            //string[] masinf = new string[3];
            //string[] s = new string[]{"Плательщик1=", "ПлательщикСчет=", "ПлательщикИНН=" };
            //if (upload != null)
            //{
            //    // получаем имя файла
            //    string fileName = System.IO.Path.GetFileName(upload.FileName);
            //    // сохраняем файл в папку Files в проекте
            //    upload.SaveAs("D:/" + fileName);
            //    string fileput = "D:/" + fileName;
            //// Read the file and display it line by line.  
            //System.IO.StreamReader file =
            //    new System.IO.StreamReader(fileput, Encoding.Default);
            //while ((line = file.ReadLine()) != null)
            //{
            //    if (line.IndexOf(s[0]) > -1)
            //        masinf[0] = Regex.Replace(line, s[0], String.Empty);
            //    if (line.IndexOf(s[1]) > -1)
            //        masinf[1] = Regex.Replace(line, s[1], String.Empty);
            //    if (line.IndexOf(s[2]) > -1)
            //    {
            //        masinf[2] = Regex.Replace(line, s[2], String.Empty);
            //        Listcontragent.Add(new ContrAgent() { Name = masinf[0], Schet = masinf[1], INN = masinf[2] });
            //    }
            //}
            //file.Close();
            //    }
            //foreach (var contrag in Listcontragent)
            //{
            //    ContragentRepository repo = new ContragentRepository();

            //    repo.Create(contrag);
            //    //db.ContrAgents.Add(contrag);
            //    //db.SaveChanges();
            //}
            //db.SaveChanges();
        //    return View("Index");
        }
    }
}
