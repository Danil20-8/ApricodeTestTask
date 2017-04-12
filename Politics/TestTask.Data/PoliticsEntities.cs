using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Politics.Model;
using Politics.Data.Configurations;

namespace Politics.Data
{
    public class PoliticsEntities : DbContext
    {
        public PoliticsEntities() : base(typeof(PoliticsEntities).Name) { }

        DbSet<Region> Regions { get; set; }
        DbSet<Order> Orders { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new RegionConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
        }

    }
}
