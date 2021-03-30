using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication7.DbModel
{
    public class Feature:BaseClass
    {
        public string Icon { get; set; }
        public string Description { get; set; }
    }
}