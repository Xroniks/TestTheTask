using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestTheTask.Models
{
    public class ContrAgentContext : DbContext
    {
        public DbSet<ContrAgent> ContrAgents { get; set; }
    }
}