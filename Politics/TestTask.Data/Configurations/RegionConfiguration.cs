using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Politics.Model;

namespace Politics.Data.Configurations
{
    public class RegionConfiguration : EntityTypeConfiguration<Region>
    {
        public RegionConfiguration()
        {
            ToTable("Regions");
            Property(r => r.Name).IsRequired();
            Property(r => r.Authority).IsRequired();

            HasOptional(r => r.Parent).WithMany(r => r.Childs).HasForeignKey(r => r.ParentID);
            HasMany(r => r.Orders).WithRequired(o => o.Region).HasForeignKey(o => o.RegionID);
        }
    }
}
