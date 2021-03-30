using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication7.DbModel
{
    public class Service : BaseClass
    {
        public Service()
        {
            ServiceComponents = new List<ServiceComponent>();
        }
        public virtual List<ServiceComponent> ServiceComponents { get; set; }
    }
}