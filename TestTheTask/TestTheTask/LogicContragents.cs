using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using TestTheTask.Models;
using System.Text;
using System.Text.RegularExpressions;


namespace TestTheTask
{

    public static class LogicContragents
    {
        public static List<Contragent> ParsFile(HttpPostedFileBase upload)
        {
            List<Contragent> ListСontragentOfFile = new List<Contragent>();
            HashSet<string> NoDuplicate = new HashSet<string>();

            const string NameContragent = "Плательщик1=";
            const string Checkingaccount = "Плательщик2=";
            const string Bik = "ПлательщикБИК=";
            const string Inn = "ПлательщикИНН=";
            const string EndDoc = "КонецДокумента";

            if (upload != null)
            {

                string fileName = System.IO.Path.GetFileName(upload.FileName);
                upload.SaveAs("D:/" + fileName);
                string fileput = "D:/" + fileName;
                string[] LinesFiles = File.ReadAllLines(fileput, Encoding.Default);

                var ContragentFind = new Contragent();

                foreach (var Line in LinesFiles)
                {
                    if (Line.Contains(NameContragent))
                        ContragentFind.NameContragent = Regex.Replace(Line, NameContragent, String.Empty);

                    if (Line.Contains(Checkingaccount))
                        ContragentFind.Checkingaccount = Regex.Replace(Line, Checkingaccount, String.Empty);

                    if (Line.Contains(Bik))
                        ContragentFind.Bik = Regex.Replace(Line, Bik, String.Empty);

                    if (Line.Contains(Inn)) 
                        ContragentFind.Inn = Regex.Replace(Line, Inn, String.Empty);

                    if (Line == EndDoc && NoDuplicate.Add(ContragentFind.Inn))
                    {
                        ListСontragentOfFile.Add(new Contragent(){ NameContragent = ContragentFind.NameContragent, Checkingaccount = ContragentFind.Checkingaccount, Bik = ContragentFind.Bik,  Inn = ContragentFind.Inn });
                        ContragentFind.NameContragent = "-";
                        ContragentFind.Checkingaccount = "-";
                        ContragentFind.Bik = "-";
                        ContragentFind.Inn = "-";
                    }
                }

            }
                
            return ListСontragentOfFile;
        }

        public static void UploadinBd(List<Contragent> ListСontragentOfFile)
        {
            ContragentRepository ReposContagents = new ContragentRepository();

            foreach (var Сontragent in ListСontragentOfFile)
            {
                ReposContagents.CreateContragent(Сontragent);
            }
        }
    }
}