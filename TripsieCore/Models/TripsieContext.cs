using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripsieCore.Models
{
    public class TripsieContext : DbContext
    {
        private IConfigurationRoot _config;

        public TripsieContext(IConfigurationRoot config, DbContextOptions options)
        {
            _config = config;
        }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<ActivityVote> ActivityVotes { get; set; }
        public DbSet<PushRegistrations> PushRegistrations { get; set; }
        public DbSet<TripActivity> TripActivities { get; set; }
        public DbSet<TripComment> TripComments { get; set; }
        //public DbSet<TripStatus> TripStatuses { get; set; }
        public DbSet<TripUser> TripUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config["ConnectionStrings:TripsieContextConnection"]);
        }
    }
}
