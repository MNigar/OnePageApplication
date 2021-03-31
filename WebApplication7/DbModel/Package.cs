using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication7.DbModel
{
    public class Package:BaseClass
    {
        public decimal PacketPrice { get; set; }
        public virtual Price Price { get; set; }
        public int PriceId { get; set; }
        public int DiskSpace { get; set; }
        public string Support { get; set; }
        public int DomainCount { get; set; }
        public int EmailCount { get; set; }
    }
}