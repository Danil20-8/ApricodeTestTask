using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Politics.Model
{
    public class Order
    {
        public int OrderID { get; set; }
        public string Name { get; set; }
        public string Act { get; set; }
        public Authority Authority { get; set; }
       
        public int RegionID { get; set; }
        public virtual Region Region { get; set; }
    }
}
