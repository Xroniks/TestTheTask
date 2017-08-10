using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestFileWork
{
    public class Contragent
    {
        public string name;
        public string check;
        public string inn;

        public void wri()
        {
            System.Console.Write(name);
            System.Console.Write(check);
            System.Console.WriteLine(inn);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Contragent> Listcontragent = new List<Contragent>();
            Console.OutputEncoding = Encoding.GetEncoding(1251);
            int Counter = 0;
            string line;
            string[] masinf = new string[3];
            string s1 = "ПлательщикСчет=";
            string s2 = "Плательщик1=";
            string s3 = "ПлательщикИНН=";

            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"c:\test.txt", Encoding.Default);
            while ((line = file.ReadLine()) != null)
            {
                if (line.IndexOf(s1) > -1)
                    masinf[0] = Regex.Replace(line, s1, String.Empty);     
                if (line.IndexOf(s2) > -1)
                    masinf[1] = Regex.Replace(line, s2, String.Empty);
                if (line.IndexOf(s3) > -1)
                {
                    masinf[2] = Regex.Replace(line, s3, String.Empty);
                    Listcontragent.Add(new Contragent(){name = masinf[0], check = masinf[1], inn = masinf[2]});
                }
            }
            foreach (var contragent in Listcontragent)
            {
                contragent.wri();
            }
            file.Close();
            System.Console.ReadLine();

        }
    }
}
