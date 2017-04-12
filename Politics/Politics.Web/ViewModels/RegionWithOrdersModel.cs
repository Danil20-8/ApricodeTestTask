using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Politics.Model;

namespace Politics.Web.ViewModels
{
    public class RegionWithOrdersModel
    {
        public string Name { get; set; }
        public int RegionID { get; set; }
        public IEnumerable<OrderShortModel> OrdersOf { get; set; }
        public IEnumerable<OrderShortModel> OrdersIn { get; set; }

        public static RegionWithOrdersModel Init(Region region, IEnumerable<Order> ordersOf, IEnumerable<Order> ordersIn)
        {
            return new RegionWithOrdersModel
            {
                Name = region.Name,
                RegionID = region.RegionID,
                OrdersOf = ordersOf.Select(o => OrderShortModel.Init(o)),
                OrdersIn = ordersIn.Select(o => OrderShortModel.Init(o))
            };
        }
    }
}