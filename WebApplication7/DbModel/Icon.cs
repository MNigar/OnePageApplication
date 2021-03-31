using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication7.DbModel
{
    public class Icon:BaseClass
    {
        public Icon()
        {
            SocialMedias = new List<SocialMedia>();
        }
        public string Icons { get; set; }
        public virtual List<SocialMedia> SocialMedias { get; set; }
    }
}