using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Politics.Model;

namespace Politics.Data
{
    public class PoliticsDataSeed : DropCreateDatabaseIfModelChanges<PoliticsEntities>
    {
        protected override void Seed(PoliticsEntities context)
        {
            var rootRegion = new Region
            {
                Name = "Milky Way",
                Authority = Authority.None
            };
            rootRegion.Childs = new List<Region>
            {
                new Region
                {
                    Name = "Earth",
                    Authority = Authority.Executive
                },
                new Region
                {
                    Name = "Mars",
                    Authority = Authority.Executive
                },
                new Region
                {
                    Name = "Saturn",
                    Authority = Authority.Legislative
                }
            };

            context.Set<Region>().Add(rootRegion);

            Order order = new Order
            {
                Name = "66",
                Act = "Kill all jedi",
                Authority = Authority.Executive,
                Region = rootRegion
            };

            context.Set<Order>().Add(order);

            context.Commit();
        }
    }
}
