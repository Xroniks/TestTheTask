using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using TestTheTask.Models;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;


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

            //if (upload.HasFile)
            //{
            //    StreamReader reader = new StreamReader(upload.FileContent);
            //    do
            //    {
            //        string textLine = reader.ReadLine();

            //        // do your coding 
            //        //Loop trough txt file and add lines to ListBox1  

            //    } while (reader.Peek() != -1);
            //    reader.Close();
            //}

            string result = new StreamReader(upload.InputStream).ReadToEnd();

            Encoding ascii = Encoding.ASCII;
            Encoding unicode = Encoding.Unicode;


            //byte[] unicodeBytes = unicode.GetBytes(result);

            //byte[] asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);

            //char[] asciiChars = new char[ascii.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
            //ascii.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);
            //string asciiString = new string(asciiChars);

            byte[] asciiBytes = ascii.GetBytes(result);
            byte[] unicodeBytes = Encoding.Convert(ascii, unicode, asciiBytes);

            char[] unicodeChars = new char[unicode.GetCharCount(unicodeBytes, 0, unicodeBytes.Length)];
            unicode.GetChars(unicodeBytes, 0, unicodeBytes.Length, unicodeChars, 0);
            string asciiString = new string(unicodeChars);


            byte[] buffer = new byte[upload.InputStream.Length];
            upload.InputStream.Seek(0, SeekOrigin.Begin);
            upload.InputStream.Read(buffer, 0, Convert.ToInt32(upload.InputStream.Length));
            Stream stream2 = new MemoryStream(buffer);

            string LineOfFile;
            List<string> slist = new List<string>();
            StreamReader file = new StreamReader(stream2, Encoding.Default);
            while ((LineOfFile = file.ReadLine()) != null)
            {
               slist.Add(LineOfFile);

            }



            StringReader strReader = new StringReader(asciiString);


            
            

                if (upload != null)
            {

                //string fileName = System.IO.Path.GetFileName(upload.FileName);
                //upload.SaveAs("D:/" + fileName);
                //string fileput = "D:/" + fileName;

                //string[] LinesFiles = File.ReadAllLines(fileput, Encoding.Default);

                var ContragentFind = new Contragent();

                foreach (var Line in slist)
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