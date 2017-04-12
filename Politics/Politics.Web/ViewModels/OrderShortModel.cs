using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Politics.Model;


namespace Politics.Web.ViewModels
{
    public class OrderShortModel
    {
        public string Name { get; set; }
        public int OrderID { get; set; }

        public static OrderShortModel Init(Order order)
        {
            return new OrderShortModel
            {
                Name = order.Name,
                OrderID = order.OrderID
            };
        }
    }
}