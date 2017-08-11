using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestTheTask.Models;
using System.Text;
using System.Text.RegularExpressions;


namespace TestTheTask
{
    public static class Logic
    {
        public static void Insert(HttpPostedFileBase upload)
        {
            // Объявляем коллекцию для парсинга загруженного файла
            List<Contragent> ListСontragentOfFile = new List<Contragent>();

            // Объявляем класс для работы с базами данных
            ContragentRepository ReposContagents = new ContragentRepository();

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
                System.IO.StreamReader file =
                    new System.IO.StreamReader(fileput, Encoding.Default);
                while ((LineOfFile = file.ReadLine()) != null)
                {
                    var contragent = new Contragent();
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

                foreach (var Сontragent in ListСontragentOfFile)
                {
                    ReposContagents.CreateContragent(Сontragent);
                }
            }
        }
    }
}