using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace TestTheTask.Models
{
    public class ContragentRepository
    {
        //Подключение к требуемой базе данных
        string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


        //Получение списка всех контрагентов
        public List<Contragent> GetContragents()
        {
            List<Contragent> Contragents = new List<Contragent>();
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                Contragents = db.Query<Contragent>("SELECT * FROM Contragents").ToList();
            }
            return Contragents;
        }

        //Получение контрагента с требуемым id
        public Contragent GetContragent(int id)
        {
            Contragent Contragent = null;
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                Contragent = db.Query<Contragent>("SELECT * FROM Contragents WHERE Id = @id", new { id }).FirstOrDefault();
            }
            return Contragent;
        }

        //Создание и добавление контрагента в базу данных
        public void CreateContragent(Contragent Contragent)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var sqlQuery = "INSERT INTO Contragents (NameContragent, Checkingaccount, Inn) VALUES(@NameContragent, @Checkingaccount, @Inn)";
                db.Execute(sqlQuery, Contragent);
            }
        }
    }
}
