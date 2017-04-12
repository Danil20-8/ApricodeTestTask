using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Politics.Service
{
    public class OrderIsNotExistException : ServiceException
    {
        public int OrderID { get; private set; }

        public override object Model => OrderID;

        public OrderIsNotExistException(int orderId)
            :base($"Order with id {orderId} is not exist")
        {
            OrderID = orderId;
        }
    }
}
