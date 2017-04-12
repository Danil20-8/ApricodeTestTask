using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Politics.Service
{
    public class RegionIsNotExistException : ServiceException
    {
        public int RegionID { get; private set; }

        public override object Model => RegionID;

        public RegionIsNotExistException(int regionId)
            :base($"Region with id {regionId} is not found")
        {
            RegionID = regionId;
        }
    }
}
