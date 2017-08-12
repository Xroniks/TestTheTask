using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using TestTheTask.Models;
using System.Text;
using System.Text.RegularExpressions;


namespace TestTheTask
{

    public static class Logic
    {


        public static List<Contragent> Insert(HttpPostedFileBase upload)
        {
            // Объявляем коллекцию для парсинга загруженного файла
            List<Contragent> ListСontragentOfFile = new List<Contragent>();

            HashSet<string> oddNumbers = new HashSet<string>();

            string LineOfFile; // Строка для просмотра файла в построчном режиме
            string[] MasFieldsInfContragent = new string[3]; // Массив для набора данных перед добавлением объекта в коллекцию
            string[] MasNameFields = {"Плательщик1=", "ПлательщикСчет=", "ПлательщикИНН="};

            if (upload != null)
            {
                // Получаем имя файла
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                // Сохраняем файл
                upload.SaveAs("D:/" + fileName);
                string fileput = "D:/" + fileName;
                // Прочитываем файл и показываем его по строкам.

                StreamReader file =
                    new StreamReader(fileput, Encoding.Default);
                while ((LineOfFile = file.ReadLine()) != null)
                {
                    if (LineOfFile.Contains(MasNameFields[0]))
                        MasFieldsInfContragent[0] = Regex.Replace(LineOfFile, MasNameFields[0], String.Empty);
                    if (LineOfFile.IndexOf(MasNameFields[1]) > -1)
                        MasFieldsInfContragent[1] = Regex.Replace(LineOfFile, MasNameFields[1], String.Empty);
                    if (LineOfFile.IndexOf(MasNameFields[2]) > -1)
                    {
                        MasFieldsInfContragent[2] = Regex.Replace(LineOfFile, MasNameFields[2], String.Empty);
                        if (oddNumbers.Add(MasFieldsInfContragent[0]))
                        ListСontragentOfFile.Add(new Contragent() { NameContragent = MasFieldsInfContragent[0], Checkingaccount = MasFieldsInfContragent[1], Inn = MasFieldsInfContragent[2]});
                    }
                }
                
                file.Close();
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