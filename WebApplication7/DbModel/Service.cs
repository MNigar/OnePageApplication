using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication7.DbModel
{
    public class Service 
    {   
        public Service()
        {
            ServiceComponents = new List<ServiceComponent>();
        }
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public virtual List<ServiceComponent> ServiceComponents { get; set; }
    }
}