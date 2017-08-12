using System.Collections.Generic;
using System.Web.Http;
using TestTheTask.Models;

namespace TestTheTask.Controllers
{
    public class ValuesController : ApiController
    {
        ContragentRepository ReposContragents = new ContragentRepository();
        //ContrAgentContext db = new ContrAgentContext();

        // GET api/values
        public IEnumerable<Contragent> GetContrAgents()
        {

            return ReposContragents.GetContragents(); 
            //return db.ContrAgents;
        }

        // GET api/values/5
        public Contragent GetContrAgent(int id)
        {
            
            return ReposContragents.GetContragent(id);
        }

        // POST api/values
        [HttpPost]
        public void CreateContrAgents([FromBody]IEnumerable<Contragent> Contragents)
        {
            foreach (var a in Contragents)
            {
                ReposContragents.CreateContragent(a);
            }
        }
    }
}
