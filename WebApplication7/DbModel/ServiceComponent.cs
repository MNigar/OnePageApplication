using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication7.DbModel
{
    public class ServiceComponent
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public int ServiceId { get; set; }
    }
}