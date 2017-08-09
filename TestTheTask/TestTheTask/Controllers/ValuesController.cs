using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestTheTask.Models;

namespace TestTheTask.Controllers
{
    public class ValuesController : ApiController
    {
        
        ContrAgentContext db = new ContrAgentContext();

        // GET api/values
        public IEnumerable<ContrAgent> GetContrAgents()
        {
            return db.ContrAgents;
        }

        // GET api/values/5
        public ContrAgent GetContrAgent(int id)
        {
            ContrAgent ContrAgent = db.ContrAgents.Find(id);
            return ContrAgent;
        }

        // POST api/values
        [HttpPost]
        public void CreateContrAgent([FromBody]ContrAgent ContrAgent)
        {
            db.ContrAgents.Add(ContrAgent);
            db.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut]
        public void EditBook(int id, [FromBody]ContrAgent ContrAgent)
        {
            if (id == ContrAgent.Id)
            {
                db.Entry(ContrAgent).State = EntityState.Modified;

                db.SaveChanges();
            }
        }

        // DELETE api/values/5
        public void DeleteBook(int id)
        {
            ContrAgent ContrAgent = db.ContrAgents.Find(id);
            if (ContrAgent != null)
            {
                db.ContrAgents.Remove(ContrAgent);
                db.SaveChanges();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
