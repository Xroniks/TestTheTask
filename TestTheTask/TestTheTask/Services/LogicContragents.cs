using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using TestTheTask.Models;

namespace TestTheTask.Services
{

    public static class LogicContragents
    {
        public static List<Contragent> ParsFile(HttpPostedFileBase UploadFile)
        {
            const string NameContragent = "Плательщик1=";
            const string Checkingaccount = "Плательщик2=";
            const string Bik = "ПлательщикБИК=";
            const string Inn = "ПлательщикИНН=";
            const string EndDoc = "КонецДокумента";

            List<Contragent> ListСontragentOfFile = new List<Contragent>();
            List<string> MasStringOfFile = new List<string>();
            HashSet<string> NoDuplicate = new HashSet<string>();

            string LineOfFile;

            Contragent ContragentFind = new Contragent();

            if (UploadFile != null)
            {
                byte[] buffer = new byte[UploadFile.InputStream.Length];
                UploadFile.InputStream.Seek(0, SeekOrigin.Begin);
                UploadFile.InputStream.Read(buffer, 0, Convert.ToInt32(UploadFile.InputStream.Length));
                Stream streamfile = new MemoryStream(buffer);
                StreamReader file = new StreamReader(streamfile, Encoding.Default);

                while ((LineOfFile = file.ReadLine()) != null)
                {
                    MasStringOfFile.Add(LineOfFile);

                }

                foreach (var StringOfFile in MasStringOfFile)
                {
                    if (StringOfFile.Contains(NameContragent))
                        ContragentFind.NameContragent = Regex.Replace(StringOfFile, NameContragent, String.Empty);

                    if (StringOfFile.Contains(Checkingaccount))
                        ContragentFind.Checkingaccount = Regex.Replace(StringOfFile, Checkingaccount, String.Empty);

                    if (StringOfFile.Contains(Bik))
                        ContragentFind.Bik = Regex.Replace(StringOfFile, Bik, String.Empty);

                    if (StringOfFile.Contains(Inn)) 
                        ContragentFind.Inn = Regex.Replace(StringOfFile, Inn, String.Empty);

                    if (StringOfFile == EndDoc && NoDuplicate.Add(ContragentFind.NameContragent))
                    {
                        ListСontragentOfFile.Add(new Contragent(){ NameContragent = ContragentFind.NameContragent, Checkingaccount = ContragentFind.Checkingaccount, Bik = ContragentFind.Bik,  Inn = ContragentFind.Inn });
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