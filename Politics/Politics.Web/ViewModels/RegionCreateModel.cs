using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Politics.Model;

namespace Politics.Web.ViewModels
{
    public class RegionCreateModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Authority? Authority { get; set; }

        public Region DomainRegion =>
                new Region
                {
                    Name = Name,
                    Authority = Authority.Value
                };
    }
}