using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication7.DbModel
{
    public class SocialMedia : BaseClass
    {   public int IconId { get; set; }
        public virtual Icon Icon { get; set; }
        public int SettingId { get; set; }
        public virtual Setting Setting{get; set;} 
        public string Link { get; set; }

    }
}