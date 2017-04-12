using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Politics.Model;

namespace Politics.Web.ViewModels
{
    public class RegionShortModel
    {
        public int RegionID { get; set; }
        public string Name { get; set; }

        public static RegionShortModel Init(Region region)
        {
            return new RegionShortModel
            {
                RegionID = region.RegionID,
                Name = region.Name
            };
        }
    }
}