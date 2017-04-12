using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Politics.Model;

namespace Politics.Web.ViewModels
{
    public class OrderModel
    {
        public string Name { get; set; }
        public string Act { get; set; }
        public Authority Authority { get; set;}
        public RegionShortModel Region { get; set; }
        public IEnumerable<RegionShortModel> Regions { get; set; }

        public static OrderModel Init(Order order, IEnumerable<Region> regions)
        {
            return new OrderModel
            {
                Name = order.Name,
                Act = order.Act,
                Authority = order.Authority,
                Region = RegionShortModel.Init(order.Region),
                Regions = regions.Select(r => RegionShortModel.Init(r))
            };
        }
    }
}