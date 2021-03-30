using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication7.DbModel
{
    public class Project:BaseClass
    {
        public string Photo { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}