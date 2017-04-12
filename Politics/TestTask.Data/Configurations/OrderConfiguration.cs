using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Politics.Model;

namespace Politics.Data.Configurations
{
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            ToTable("Orders");
            Property(o => o.Name).IsRequired();
            Property(o => o.Authority).IsRequired();

            HasRequired(o => o.Region).WithMany(r => r.Orders).HasForeignKey(o => o.RegionID);
        }
    }
}
