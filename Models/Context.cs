using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HealthAPI.Models
{
    public class Context : DbContext
    {

        public Context()
        {

        }

        public DbSet<BloodSugar> BloodSugars { get; set; }
        public DbSet<Pressure> Pressures { get; set; }
        public DbSet<Pulse> Pulses { get; set; }
        public DbSet<Weight> Weights { get; set; }
        public DbSet<User> Users { get; set; }

    }
}