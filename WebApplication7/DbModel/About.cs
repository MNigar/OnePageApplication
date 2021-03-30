using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication7.DbModel
{
    public class About
    {

        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        [MinLength(5)]
        public string Title { get; set; }
        [MaxLength(20)]
        [MinLength(5)]
        public string PreTitle { get; set; }
        [MaxLength(20)]
        [MinLength(5)]
        public string Text { get; set; }
        [MaxLength(255)]
        [MinLength(5)]
        public string Signature { get; set; }
    }
}