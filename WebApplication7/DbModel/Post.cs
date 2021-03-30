using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication7.DbModel
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? Date { get; set; }
        public string Photo { get; set; }
        public string Tag { get; set; }
        public string Text { get; set; }
    }
}