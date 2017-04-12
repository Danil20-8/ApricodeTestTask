using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Politics.Data.Infrastructure
{
    public class DbFactory : IDbFactory
    {
        PoliticsEntities dbContext;

        public PoliticsEntities Init()
        {
            return dbContext ?? (dbContext = new PoliticsEntities());
        }

        public void Dispose()
        {
            dbContext?.Dispose();
        }
    }
}
