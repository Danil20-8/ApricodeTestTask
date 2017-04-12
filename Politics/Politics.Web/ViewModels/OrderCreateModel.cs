using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Politics.Model;

namespace Politics.Web.ViewModels
{
    public class OrderCreateModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Act { get; set; }
        [Required]
        public Authority? Authority { get; set; }

        public Order GetDomainModel(Region region)
        {
            return new Order
            {
                Name = Name,
                Act = Act,
                Authority = Authority.Value,
                Region = region
            };
        }
    }
}