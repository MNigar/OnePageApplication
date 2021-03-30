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
        public DbSet<About> About { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Fact> Fact { get; set; }
        public DbSet<Feature> Feature { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Package> Package { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<ServiceComponent> ServiceComponent { get; set; }
        public DbSet<Setting> Setting { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<SocialMedia> SocialMedia { get; set; }

    }
}