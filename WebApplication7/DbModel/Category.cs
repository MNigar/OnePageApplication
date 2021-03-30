using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication7.DbModel
{
    public class Category:BaseClass
    {
        public Category()
        {
            Projects = new HashSet<Project>();
        }
        public int OrderBy { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}