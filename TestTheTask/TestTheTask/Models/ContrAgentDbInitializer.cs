using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TestTheTask.Models
{
    public class ContrAgentDbInitializer : DropCreateDatabaseAlways<ContrAgentContext>
    {
        protected override void Seed(ContrAgentContext db)
        {
            //Заполнили базу данных стандартными данными
            db.ContrAgents.Add(new ContrAgent { Name = "Война и мир", Author = "Л. Толстой", Age = 1863 });
            db.ContrAgents.Add(new ContrAgent { Name = "Отцы и дети", Author = "И. Тургенев", Age = 1862 });
            db.ContrAgents.Add(new ContrAgent { Name = "Чайка", Author = "А. Чехов", Age = 1896 });

            base.Seed(db);
        }
    }
}