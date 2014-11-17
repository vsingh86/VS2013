using ETLDomain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace ETLWebApi.Models
{
    public class ETLContext : DbContext 
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Project> Projects{ get; set; }
    }
}