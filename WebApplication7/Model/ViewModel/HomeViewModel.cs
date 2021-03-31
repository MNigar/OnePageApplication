using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication7.DbModel;

namespace WebApplication7.Model.ViewModel
{
    public class HomeViewModel
    {
        public List<Feature> Feature { get; set; }
        public About About { get; set; }
        public Service Service { get; set; }
        public List<ServiceComponent> ServiceComponent { get; set; }
        public Price Price { get; set; }
        
    }
}