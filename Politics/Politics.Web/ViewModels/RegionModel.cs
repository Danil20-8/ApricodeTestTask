using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Politics.Model;

namespace Politics.Web.ViewModels
{
    public class RegionModel
    {
        public int RegionID { get; set; }
        public string Name { get; set; }
        public Authority Authority { get; set; }
        public IEnumerable<RegionShortModel> Parents { get; set; }
        public IEnumerable<RegionShortModel> Childs { get; set; }

        public static RegionModel Init(Region region)
        {
            return new RegionModel
            {
                RegionID = region.RegionID,
                Name = region.Name,
                Authority = region.Authority,
                Parents = region.GetParents().Select(r => RegionShortModel.Init(r)),
                Childs = region.Childs.Select(c => RegionShortModel.Init(c))
            };
        }
    }
}