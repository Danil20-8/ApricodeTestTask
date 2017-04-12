using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Politics.Model;

namespace Politics.Data.Infrastructure
{
    public class RegionRepository : RepositoryBase<Region>, IRegionRepository
    {
        public RegionRepository(IDbFactory dbFactory)
            :base(dbFactory)
        {
        }

    }

    public interface IRegionRepository : IRepository<Region>
    {

    }
}
