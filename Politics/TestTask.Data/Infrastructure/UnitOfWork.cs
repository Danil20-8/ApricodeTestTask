using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Politics.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly IDbFactory dbFactory;
        PoliticsEntities dbContext;

        public PoliticsEntities DbContext => dbContext ?? (dbContext = dbFactory.Init());

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public void Commit()
        {
            DbContext.Commit();
        }
    }
}
