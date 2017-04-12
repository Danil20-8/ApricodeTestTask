using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Politics.Model
{
    public class Region
    {
        public int RegionID { get; set; }
        public string Name { get; set; }
        public Authority Authority { get; set; }

        public int? ParentID { get; set; }
        public virtual Region Parent { get; set; }
        public virtual List<Region> Childs { get; set; }

        public virtual List<Order> Orders { get; set; }

        #region Methods
        public Region GetRoot()
        {
            var curr = this;
            var parent = Parent;
            while (parent != null)
            {
                curr = parent;
                parent = curr.Parent;
            }
            return curr;
        }
        public IEnumerable<Region> GetParents(bool includeSelf = false)
        {
            var curr = (includeSelf ? this : Parent);
            while (curr != null)
            {
                yield return curr;
                curr = curr.Parent;
            }
        }
        public IEnumerable<Region> GetFlatten()
        {
            return GetFlatten(new Region[] { this });
        }
        public static IEnumerable<Region> GetFlatten(IEnumerable<Region> regions)
        {
            return regions.Concat(regions.SelectMany(r => GetFlatten(r.Childs)));
        }
        #endregion
    }

    public enum Authority
    {
        Legislative,
        Executive,
        None
    }
}
