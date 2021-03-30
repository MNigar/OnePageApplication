using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication7.DbModel
{
    public class Feedback
    {   [Key]
        public int Id { get; set; }

        public string Holder { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }

    }
}