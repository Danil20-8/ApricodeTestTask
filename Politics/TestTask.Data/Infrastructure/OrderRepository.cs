using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Politics.Model;
namespace Politics.Data.Infrastructure
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }
    }

    public interface IOrderRepository : IRepository<Order>
    {
    }
}
