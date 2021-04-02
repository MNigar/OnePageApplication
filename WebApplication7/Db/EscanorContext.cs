using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication7.DbModel;

namespace WebApplication7.Db
{
    public class EscanorContext:DbContext
    {
        public EscanorContext() : base("Escanor")
        {

        }
        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Fact> Facts { get; set; }
        public virtual DbSet<Feature> Features { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceComponent> ServiceComponents { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<SocialMedia> SocialMedias { get; set; }
        public virtual DbSet<Icon> Icons { get; set; }
        public virtual DbSet<User> Users { get; set; }

    }
}