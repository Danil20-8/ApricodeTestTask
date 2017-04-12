using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Politics.Service
{
    public class ServiceException : Exception
    {
        public virtual string Name => GetType().Name.Replace("Exception", "");
        public virtual object Model => null;
        public ServiceException(string message = "", Exception inner = null)
            :base(message, inner)
        {
        }
    }
}
