using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace TestTheTask.Models
{
    public class ContragentRepository
    {

        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public List<ContrAgent> GetUsers()
        {
            List<ContrAgent> users = new List<ContrAgent>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                users = db.Query<ContrAgent>("SELECT * FROM ContrAgents").ToList();
            }
            return users;
        }

        public ContrAgent Get(int id)
        {
            ContrAgent user = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                user = db.Query<ContrAgent>("SELECT * FROM ContrAgents WHERE Id = @id", new { id }).FirstOrDefault();
            }
            return user;
        }

        public void Create(ContrAgent contragent)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                //var sqlQuery = "INSERT INTO ContrAgents (Name, Check, INN) VALUES(@Name, @Check, @INN); SELECT CAST(SCOPE_IDENTITY() as int)";
                //db.Execute(sqlQuery, contragent);
                //var userId = db.Query<int>(sqlQuery, contragent).FirstOrDefault();
                //contragent.Id = userId;

                var sqlQuery = "INSERT INTO ContrAgents (Name, Check, INN) VALUES(@Name, @Check, @INN)";
                db.Execute(sqlQuery, contragent);
            }
            //return contragent;
        }

        public void Update(ContrAgent contragent)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Users SET Name = @Name, Age = @Age WHERE Id = @Id";
                db.Execute(sqlQuery, contragent);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Users WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}
