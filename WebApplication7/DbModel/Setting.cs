using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication7.DbModel
{
    public class Setting
    {   public Setting()
        {
            SocialMedia = new List<SocialMedia>();
        }
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        [MinLength(3)]
        public string Logo { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string SubFooterText { get; set; }
        public string IntroPhoto { get; set; }
        public virtual List<SocialMedia> SocialMedia { get; set; }
    }
}