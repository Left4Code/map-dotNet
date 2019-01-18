using Formation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formation.Data
{
    public class FormationContext:DbContext
    {
        public FormationContext():base("name=machaine")
        {

        }

        // Les DbSet des entites
        public DbSet<Film> Films { get; set; }
        public DbSet<Producer> Producers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // les config + conventions
        }


    }
}
