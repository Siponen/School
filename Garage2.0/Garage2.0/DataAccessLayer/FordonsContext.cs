using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2._0.DataAccessLayer
{
    public class FordonsContext : DbContext
    {
        public FordonsContext() : base("DefaultConnection")
        {
        }

        public DbSet<Models.Fordon> Fordons { get; set; }
    }
}