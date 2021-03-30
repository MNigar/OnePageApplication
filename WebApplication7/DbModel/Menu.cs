using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication7.DbModel
{
    public class Menu:BaseClass
    {
        public bool IsVisible { get; set; }
        public int Orderby { get; set; }
    }
}